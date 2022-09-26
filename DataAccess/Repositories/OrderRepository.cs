using Microsoft.EntityFrameworkCore;
using RestaurantMenu_v3_CodeFirst.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantMenu_v3_CodeFirst.DataAccess.Repositories
{
    //create interface
    public interface IOrderRepository
    {
        //add each method in interface
        Task<ICollection<Order>> GetAllAsync();
        Task AddAsync(Order orders);
        Task UpdateAsync(Order orders);
        Task<Order> GetByIdAsync(int id);
        Task DeleteAsync(Order orders);
    }
    //OrderRepository - class which allows us to work with DB
    class OrderRepository : IOrderRepository
    {
        //reference to MenuDataContext
        private readonly MenuDataContext _context;

        //initiate this field via constructor
        public OrderRepository(MenuDataContext context)
        {
            this._context = context;
        }

        public async Task<ICollection<Order>> GetAllAsync()
        {
            return (ICollection<Order>)await this._context.Orders.ToListAsync();
        }

        public async Task AddAsync(Order orders)
        {
            await this._context.Orders.AddAsync(orders);
        }

        public async Task UpdateAsync(Order orders)
        {
            this._context.Orders.Update(orders);
            await this._context.SaveChangesAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await this._context.Orders.FirstOrDefaultAsync(x => x.OrderId == id);
        }

        public async Task DeleteAsync(Order orders)
        {
            this._context.Orders.Remove(orders);
            await this._context.SaveChangesAsync();
        }
    }
}