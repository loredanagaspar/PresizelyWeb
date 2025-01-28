using Microsoft.JSInterop;

namespace PresizelyWeb.Services.Extensions
{
    // Static extension class for adding reusable methods to IJSRuntime
    public static class IJSRuntimeExtensions
    {
        /// <summary>
        /// Displays a success notification using Toastr.
        /// </summary>
        /// <param name="js">The IJSRuntime instance for invoking JavaScript functions.</param>
        /// <param name="message">The message to be displayed in the success notification.</param>
        public static async Task ToastrSuccess(this IJSRuntime js, string message)
        {
            // Invokes a JavaScript function named "ShowToastr" with "success" as the type and the provided message.
            await js.InvokeVoidAsync("ShowToastr", "success", message);
        }

        /// <summary>
        /// Displays an error notification using Toastr.
        /// </summary>
        /// <param name="js">The IJSRuntime instance for invoking JavaScript functions.</param>
        /// <param name="message">The message to be displayed in the error notification.</param>
        public static async Task ToastrError(this IJSRuntime js, string message)
        {
            // Invokes a JavaScript function named "ShowToastr" with "error" as the type and the provided message.
            await js.InvokeVoidAsync("ShowToastr", "error", message);
        }
    }
}
