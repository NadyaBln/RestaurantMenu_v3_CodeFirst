using Microsoft.EntityFrameworkCore;
using RestaurantMenu_v3_CodeFirst.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantMenu_v3_CodeFirst.DataAccess.Repositories
{
    //create interface
    public interface IProductRepository
    {
        //add each method in interface
        Task<ICollection<Product>> GetAllAsync();
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task<Product> GetByIdAsync(int id);
        Task DeleteAsync(Product product);
    }
    //OrderRepository - class which allows us to work with DB
    class ProductRepository : IProductRepository
    {
        //reference to MenuDataContext
        private readonly MenuDataContext _context;

        //initiate this field via constructor
        public ProductRepository(MenuDataContext context)
        {
            this._context = context;
        }

        public async Task<ICollection<Product>> GetAllAsync()
        {
            return (ICollection<Product>)await this._context.Products.ToListAsync();
        }

        public async Task AddAsync(Product product)
        {
            await this._context.Products.AddAsync(product);
        }

        public async Task UpdateAsync(Product product)
        {
            this._context.Products.Update(product);
            await this._context.SaveChangesAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await this._context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
        }

        public async Task DeleteAsync(Product product)
        {
            this._context.Products.Remove(product);
            await this._context.SaveChangesAsync();
        }
    }
}