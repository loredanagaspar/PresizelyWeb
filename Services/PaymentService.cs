using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PresizelyWeb.Components.Pages.Cart_Pages;
using PresizelyWeb.Data;
using PresizelyWeb.Repository;
using PresizelyWeb.Repository.IRepository;
using PresizelyWeb.Utility;
using Stripe;
using Stripe.Checkout;
using Stripe.Climate;

namespace PresizelyWeb.Services
{
    public class PaymentService
    {
        // Dependencies injected via constructor
        private readonly NavigationManager _navigationManager; 
        private readonly IOrderRepository _orderRepository;   

        public PaymentService(NavigationManager navigationManager, IOrderRepository orderRepository)
        {
            _navigationManager = navigationManager;
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// Creates a Stripe Checkout session for the given order.
        /// </summary>
        /// <param name="orderHeader">The order header containing order details.</param>
        /// <returns>A Stripe Checkout session object.</returns>
        public Session CreateStripeCheckoutSession(OrderHeader orderHeader)
        {
            // Map order details to Stripe session line items
            var lineItems = orderHeader.OrderDetails
                .Select(order => new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "gbp", // Currency set to GBP
                        UnitAmountDecimal = (decimal?)order.Price * 100, // Price in smallest currency unit 
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = order.ProductName // Product name displayed in Stripe
                        }
                    },
                    Quantity = order.Count // Number of items ordered
                }).ToList();

            // Create session options for Stripe Checkout
            var options = new Stripe.Checkout.SessionCreateOptions
            {// URL for successful payment
                SuccessUrl = $"{_navigationManager.BaseUri}order/confirmation/{{CHECKOUT_SESSION_ID}}", 
                CancelUrl = $"{_navigationManager.BaseUri}cart", // URL for canceled payment
                LineItems = lineItems, // List of line items for the session
                Mode = "payment" // Payment mode (single payment)
            };

            // Create a Stripe session using the configured options
            var service = new SessionService();
            var session = service.Create(options);

            // Return the created session
            return session;
        }

        /// <summary>
        /// Checks the payment status of a Stripe session and updates the order status.
        /// </summary>
        /// <param name="sessionId">The ID of the Stripe session.</param>
        /// <returns>The updated order header object.</returns>
        public async Task<OrderHeader> CheckPaymentStatusAndUpdateOrder(string sessionId)
        {
            // Retrieve the order associated with the session ID
            OrderHeader orderHeader = await _orderRepository.GetOrderBySessionIdAsync(sessionId);

            // Retrieve the session details from Stripe
            var service = new SessionService();
            var session = service.Get(sessionId);

            // Check if the payment status is "paid" (case-insensitive)
            if (session.PaymentStatus.ToLower() == "paid")
            {
                // Update the order status to "Approved" and save the payment intent ID
                await _orderRepository.UpdateStatusAsync(orderHeader.Id, SD.StatusApproved, session.PaymentIntentId);
            }

            // Return the updated order
            return orderHeader;
        }
    }
}

