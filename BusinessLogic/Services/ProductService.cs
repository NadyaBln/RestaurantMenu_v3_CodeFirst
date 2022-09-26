using RestaurantMenu_v3_CodeFirst.DataAccess.Repositories;
using RestaurantMenu_v3_CodeFirst.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantMenu_v3_CodeFirst.BusinessLogic_Services
{
    //create interface
    public interface IProductService
    {
        //add all methods from Controller
        Task<ICollection<Product>> GetAllAsync();
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task<bool> TryUpdateAsync(int id, Product product);
        Task<Product> GetByIdAsync(int id);
        Task DeleteAsync(Product product);
    }
    public class ProductService : IProductService
    {
        //reference to OrderRepository
        private readonly IProductRepository _repository;

        //initialization via constructor
        public ProductService(IProductRepository repository)
        {
            this._repository = repository;
        }

        //method calls method GetAllAsync from abstraction 
        public Task<ICollection<Product>> GetAllAsync()
        {
            var productsFromRepository = this._repository.GetAllAsync();
            return productsFromRepository;
        }

        public Task AddAsync(Product product)
           => this._repository.AddAsync(product);

        public Task UpdateAsync(Product product)

            => this._repository.UpdateAsync(product);

        public Task<Product> GetByIdAsync(int id)
           => this._repository.GetByIdAsync(id);

        public async Task<bool> TryUpdateAsync(int id, Product product)
        {
            var productToUpdate = await this._repository.GetByIdAsync(id);
            if (productToUpdate != null)
            {
                //productToUpdate.ProductId = product.ProductId;
                productToUpdate.Title = product.Title;
                productToUpdate.Calories = product.Calories;
                productToUpdate.Description = product.Description;
                productToUpdate.Price = product.Price;
                productToUpdate.CategoryId = product.CategoryId;
                productToUpdate.IsAlcohol = product.IsAlcohol;
                productToUpdate.IsSeason = product.IsSeason;
                productToUpdate.IsActive = product.IsActive;
                productToUpdate.AllergenId = product.AllergenId;

                await this._repository.UpdateAsync(productToUpdate);

                return true;
            }
            return false;
        }

        public Task DeleteAsync(Product product)
            => this._repository.DeleteAsync(product);

    }
}