using Microsoft.EntityFrameworkCore;
using PresizelyWeb.Data;
using PresizelyWeb.Repository.IRepository;

namespace PresizelyWeb.Repository
{
    // Repository implementation for managing Product data.
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        // Constructor to initialize the database context and web host environment.
        public ProductRepository(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        // Creates a new Product in the database.
        public async Task<Product> CreateAsync(Product obj)
        {
            await _db.Product.AddAsync(obj);
            await _db.SaveChangesAsync();
            return obj;
        }

        // Deletes a Product from the database by its ID and removes its associated image.
        public async Task<bool> DeleteAsync(int id)
        {
            var obj = await _db.Product.FirstOrDefaultAsync(u => u.Id == id);
            var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('/'));

            // Delete the associated image file if it exists.
            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }

            if (obj != null)
            {
                _db.Product.Remove(obj);
                return await _db.SaveChangesAsync() > 0; // Returns true if deletion is successful.
            }
            return false; // Returns false if the Product does not exist.
        }

        // Retrieves a single Product by its ID, including its related Category.
        public async Task<Product> GetAsync(int id)
        {
            return await _db.Product
                .Include(p => p.Category) // Eager load the Category.
                .FirstOrDefaultAsync(u => u.Id == id) ?? new Product();
        }

        // Retrieves all Products from the database, including their related Categories.
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _db.Product
                .Include(p => p.Category) // Eager load the Category.
                .ToListAsync();
        }

        // Updates an existing Product in the database.
        public async Task<Product> UpdateAsync(Product obj)
        {
            var objFromDb = await _db.Product.FirstOrDefaultAsync(u => u.Id == obj.Id);

            if (objFromDb != null)
            {
                // Update fields of the existing Product object.
                objFromDb.Name = obj.Name;
                objFromDb.Price = obj.Price;
                objFromDb.Size = obj.Size;
                objFromDb.Color = obj.Color;
                objFromDb.Stock = obj.Stock;
                objFromDb.Material = obj.Material;
                objFromDb.Description = obj.Description;
                objFromDb.ImageUrl = obj.ImageUrl;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.SizeChartJson = obj.SizeChartJson;

                _db.Product.Update(objFromDb);
                await _db.SaveChangesAsync();
                return objFromDb;
            }

            return obj; // Return the input object if the update fails.
        }
    }
}
