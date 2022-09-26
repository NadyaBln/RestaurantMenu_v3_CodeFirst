using RestaurantMenu_v3_CodeFirst.DataAccess.Repositories;
using RestaurantMenu_v3_CodeFirst.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantMenu_v3_CodeFirst.BusinessLogic_Services
{
    //create interface
    public interface IOrderItemService
    {
        //add all methods from Controller
        //it is the same as in OrderRepository
        Task<ICollection<OrderItem>> GetAllAsync();
        Task AddAsync(OrderItem orderItem);
        Task UpdateAsync(OrderItem orderItem);
        Task<bool> TryUpdateAsync(int id, OrderItem orderItem);
        Task<OrderItem> GetByIdAsync(int id);
        Task DeleteAsync(OrderItem orderItem);
    }
    public class OrderItemService : IOrderItemService
    {
        //reference to OrderRepository
        private readonly IOrderItemRepository _repository;

        //initialization via constructor
        public OrderItemService(IOrderItemRepository repository)
        {
            this._repository = repository;
        }

        //method calls method GetAllAsync from abstraction 
        public Task<ICollection<OrderItem>> GetAllAsync()
        {
            var orderItemFromRepository = this._repository.GetAllAsync();
            return orderItemFromRepository;
        }

        public Task AddAsync(OrderItem orderItem)
           => this._repository.AddAsync(orderItem);

        public Task UpdateAsync(OrderItem orderItem)

            => this._repository.UpdateAsync(orderItem);

        public Task<OrderItem> GetByIdAsync(int id)
           => this._repository.GetByIdAsync(id);

        public async Task<bool> TryUpdateAsync(int id, OrderItem orderItem)
        {
            var orderItemToUpdate = await this._repository.GetByIdAsync(id);
            if (orderItemToUpdate != null)
            {
                // orderItemToUpdate.OrderItemId = orderItem.OrderItemId;
                orderItemToUpdate.Products = orderItem.Products;
                //orderItemToUpdate.ProductId = orderItem.ProductId;
                orderItemToUpdate.Order = orderItem.Order;
                //orderItemToUpdate.OrderId = orderItem.OrderId;

                await this._repository.UpdateAsync(orderItemToUpdate);

                return true;
            }
            return false;
        }

        public Task DeleteAsync(OrderItem orderItem)
            => this._repository.DeleteAsync(orderItem);

    }
}