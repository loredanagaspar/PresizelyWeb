using Microsoft.EntityFrameworkCore;
using PresizelyWeb.Data;
using PresizelyWeb.Repository.IRepository;

namespace PresizelyWeb.Repository
{
    // Repository implementation for managing Category data.
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        // Constructor to initialize the database context.
        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        // Creates a new Category in the database.
        public async Task<Category> CreateAsync(Category obj)
        {
            await _db.Category.AddAsync(obj);
            await _db.SaveChangesAsync();
            return obj;
        }

        // Deletes a Category from the database by its ID.
        public async Task<bool> DeleteAsync(int id)
        {
            var obj = await _db.Category.FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                _db.Category.Remove(obj);
                return await _db.SaveChangesAsync() > 0; // Returns true if deletion is successful.
            }
            return false; // Returns false if the object does not exist.
        }

        // Retrieves a single Category by its ID.
        public async Task<Category> GetAsync(int id)
        {
            var obj = await _db.Category.FirstOrDefaultAsync(u => u.Id == id);
            return obj ?? new Category(); // Returns a new Category if not found.
        }

        // Retrieves all Categories from the database.
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _db.Category.ToListAsync();
        }

        // Updates an existing Category in the database.
        public async Task<Category> UpdateAsync(Category obj)
        {
            var objFromDb = await _db.Category.FirstOrDefaultAsync(u => u.Id == obj.Id);

            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name; // Updates the name field.
                _db.Category.Update(objFromDb);
                await _db.SaveChangesAsync();
                return objFromDb;
            }

            return obj; // Returns the input object if the update fails.
        }
    }
}
