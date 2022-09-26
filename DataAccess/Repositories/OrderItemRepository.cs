using Microsoft.EntityFrameworkCore;
using RestaurantMenu_v3_CodeFirst.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantMenu_v3_CodeFirst.DataAccess.Repositories
{
    //create interface
    public interface IOrderItemRepository
    {
        //add each method in interface
        Task<ICollection<OrderItem>> GetAllAsync();
        Task AddAsync(OrderItem orderItem);
        Task UpdateAsync(OrderItem orderItem);
        Task<OrderItem> GetByIdAsync(int id);
        Task DeleteAsync(OrderItem orderItem);
    }
    //OrderRepository - class which allows us to work with DB
    class OrderItemRepository : IOrderItemRepository
    {
        //reference to MenuDataContext
        private readonly MenuDataContext _context;

        //initiate this field via constructor
        public OrderItemRepository(MenuDataContext context)
        {
            this._context = context;
        }

        public async Task<ICollection<OrderItem>> GetAllAsync()
        {
            return (ICollection<OrderItem>)await this._context.OrderItems.ToListAsync();
        }

        public async Task AddAsync(OrderItem orderItem)
        {
            await this._context.OrderItems.AddAsync(orderItem);
        }

        public async Task UpdateAsync(OrderItem orderItem)
        {
            this._context.OrderItems.Update(orderItem);
            await this._context.SaveChangesAsync();
        }

        public async Task<OrderItem> GetByIdAsync(int id)
        {
            return await this._context.OrderItems.FirstOrDefaultAsync(x => x.OrderItemId == id);
        }

        public async Task DeleteAsync(OrderItem orderItem)
        {
            this._context.OrderItems.Remove(orderItem);
            await this._context.SaveChangesAsync();
        }
    }
}