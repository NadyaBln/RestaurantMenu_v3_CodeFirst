using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantMenu_v3_CodeFirst.BusinessLogic_Services;
using RestaurantMenu_v3_CodeFirst.Entities;
using RestaurantMenu_v3_CodeFirst.Models;
using System.Threading.Tasks;

namespace RestaurantMenu_v3_CodeFirst.Controllers
{
    [ApiController]
    [Route("order")]
    public class OrderController : ControllerBase
    {
        //to use automapper we should use it as dependency
        private readonly IMapper _mapper;

        //and use Interface - Interface moves us to abstraction
        //add BL layer, that's why use OrderService
        private readonly IOrderService _orderService;

        //initialization via constructor
        public OrderController(IOrderService orderService, IMapper mapper)
        {
            this._orderService = orderService;
            this._mapper = mapper;
        }


        //controller methods realization
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //use repo from constructor
            var orders = await this._orderService.GetAllAsync();

            //returns Orders in OK request 
            return this.Ok(orders);
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] OrderModel orderModel)
        {
            var dbContext = new MenuDataContext();
            dbContext.Add(new Order()
            {
                //OrderId = orderModel.OrderId,
                OrderItem = orderModel.OrderItem,
                //OrderItemId = orderModel.OrderItemId,
                CreationDateTime = orderModel.CreationDateTime,
                //GuestId = orderModel.GuestId,
                Guest = orderModel.Guest,
                TableNumber = orderModel.TableNumber
            });
            dbContext.SaveChanges();

            return this.Ok();
        }

        [HttpPut("{id:int}/edit")]
        public async Task<IActionResult> Update([FromBody] OrderModel orderModel, [FromRoute] int id)
        {
            //var dbContext = new MenuDataContext();
            //var result = dbContext.Update(Orders);

            var order = this._mapper.Map<Order>(orderModel);
            await this._orderService.TryUpdateAsync(id, order);

            return this.Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var order = await this._orderService.GetByIdAsync(id);
            if (order == null)
            {
                return this.NotFound();
            }

            return this.Ok(order);
        }

        [HttpDelete("{id:int}/delete")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var orders = await this._orderService.GetByIdAsync(id);
            if (orders != null)
            {
                await this._orderService.DeleteAsync(orders);
                return this.Ok();
            }
            return this.NotFound();
        }
    }
}