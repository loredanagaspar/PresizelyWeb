using Microsoft.EntityFrameworkCore;
using PresizelyWeb.Data;

namespace PresizelyWeb.Repository.IRepository
{
    public class ProductRepository : IProductRepository
    {

        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductRepository(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;   
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task <Product> CreateAsync(Product obj)
        {
            await _db.Product.AddAsync(obj);
            await _db.SaveChangesAsync();
            return obj;
        }

        public async Task<bool> DeleteAsync(int id)
        {
          var obj = await _db.Product.FirstOrDefaultAsync(u => u.Id == id);
            var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('/'));

            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }
            if (obj != null)
            {
                _db.Product.Remove(obj);
               return (await _db.SaveChangesAsync())>0;
            }
            return false;
        }

        public async Task<Product> GetAsync(int id)
        {
            return await _db.Product
                .Include(p => p.Category) // Include related Category
                .FirstOrDefaultAsync(u => u.Id == id) ?? new Product();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _db.Product
                  .Include(p => p.Category) // Include related Category
                  .ToListAsync();
        }

        public async Task<Product> UpdateAsync(Product obj)
        {
            var objFromDb= await _db.Product.FirstOrDefaultAsync(u=> u.Id == obj.Id);

            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.Price = obj.Price;
                objFromDb.Size = obj.Size;
                objFromDb.Color = obj.Color;
                objFromDb.Stock = obj.Stock;
                objFromDb.Material = obj.Material;
                objFromDb.Description = obj.Description;
                objFromDb.ImageUrl = obj.ImageUrl;
                objFromDb.CategoryId = obj.CategoryId;
                _db.Product.Update(objFromDb);

                await _db.SaveChangesAsync() ;
                return objFromDb;
            }

            return obj;
        }
    }
}
