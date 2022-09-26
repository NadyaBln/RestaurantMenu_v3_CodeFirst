using RestaurantMenu_v3_CodeFirst.DataAccess.Repositories;
using RestaurantMenu_v3_CodeFirst.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantMenu_v3_CodeFirst.BusinessLogic_Services
{
    //create interface
    public interface IOrderService
    {
        //add all methods from Controller
        //it is the same as in OrderRepository
        Task<ICollection<Order>> GetAllAsync();
        Task AddAsync(Order orders);
        Task UpdateAsync(Order orders);
        Task<bool> TryUpdateAsync(int id, Order order);
        Task<Order> GetByIdAsync(int id);
        Task DeleteAsync(Order orders);
    }
    public class OrderService : IOrderService
    {
        //reference to OrderRepository
        private readonly IOrderRepository _repository;

        //initialization via constructor
        public OrderService(IOrderRepository repository)
        {
            this._repository = repository;
        }

        //method calls method GetAllAsync from abstraction 
        public Task<ICollection<Order>> GetAllAsync()
        {
            var ordersFromRepository = this._repository.GetAllAsync();
            return ordersFromRepository;
        }

        public Task AddAsync(Order orders)
           => this._repository.AddAsync(orders);

        public Task UpdateAsync(Order orders)

            => this._repository.UpdateAsync(orders);

        public Task<Order> GetByIdAsync(int id)
           => this._repository.GetByIdAsync(id);

        public async Task<bool> TryUpdateAsync(int id, Order order)
        {
            var orderToUpdate = await this._repository.GetByIdAsync(id);
            if (orderToUpdate != null)
            {
                orderToUpdate.CreationDateTime = order.CreationDateTime;
                orderToUpdate.Guest = order.Guest;
                orderToUpdate.TableNumber = order.TableNumber;

                await this._repository.UpdateAsync(orderToUpdate);

                return true;
            }
            return false;
        }

        public Task DeleteAsync(Order orders)
            => this._repository.DeleteAsync(orders);
    }
}