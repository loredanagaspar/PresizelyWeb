using PresizelyWeb.Data;

namespace PresizelyWeb.Repository.IRepository
{
    // Interface for managing Product-related data operations.
    public interface IProductRepository
    {
        // Creates a new Product in the database.
        // Parameter: obj - The Product object to create.
        // Returns: The created Product object.
        public Task<Product> CreateAsync(Product obj);

        // Updates an existing Product in the database.
        // Parameter: obj - The Product object with updated information.
        // Returns: The updated Product object.
        public Task<Product> UpdateAsync(Product obj);

        // Deletes a Product from the database by its ID.
        // Parameter: id - The ID of the Product to delete.
        // Returns: True if the deletion was successful, false otherwise.
        public Task<bool> DeleteAsync(int id);

        // Retrieves a single Product by its ID.
        // Parameter: id - The ID of the Product to retrieve.
        // Returns: The Product object if found, or null if not found.
        public Task<Product> GetAsync(int id);

        // Retrieves all Products from the database.
        // Returns: An IEnumerable of all Product objects.
        public Task<IEnumerable<Product>> GetAllAsync();
    }
}
