using PresizelyWeb.Data;

namespace PresizelyWeb.Repository.IRepository
{
    // Interface for managing Category-related data operations.
    public interface ICategoryRepository
    {
        // Creates a new Category in the database.
        // Parameter: obj - The Category object to create.
        // Returns: The created Category object.
        public Task<Category> CreateAsync(Category obj);

        // Updates an existing Category in the database.
        // Parameter: obj - The Category object with updated information.
        // Returns: The updated Category object.
        public Task<Category> UpdateAsync(Category obj);

        // Deletes a Category from the database by its ID.
        // Parameter: id - The ID of the Category to delete.
        // Returns: True if the deletion was successful, false otherwise.
        public Task<bool> DeleteAsync(int id);

        // Retrieves a single Category by its ID.
        // Parameter: id - The ID of the Category to retrieve.
        // Returns: The Category object if found, or null if not found.
        public Task<Category> GetAsync(int id);

        // Retrieves all Categories from the database.
        // Returns: An IEnumerable of all Category objects.
        public Task<IEnumerable<Category>> GetAllAsync();
    }
}
