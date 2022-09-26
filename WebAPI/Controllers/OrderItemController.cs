using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantMenu_v3_CodeFirst.BusinessLogic_Services;
using RestaurantMenu_v3_CodeFirst.Entities;
using RestaurantMenu_v3_CodeFirst.Models;
using System.Threading.Tasks;

namespace RestaurantMenu_v3_CodeFirst.Controllers
{
    [ApiController]
    [Route("orderitem")]
    public class OrderItemController : ControllerBase
    {
        //to use automapper we should use it as dependency
        private readonly IMapper _mapper;

        //and use Interface - Interface moves us to abstraction
        //add BL layer, that's why use OrderService
        private readonly IOrderItemService _orderItemService;

        //initialization via constructor
        public OrderItemController(IOrderItemService orderItemService, IMapper mapper)
        {
            this._orderItemService = orderItemService;
            this._mapper = mapper;
        }




        //controller methods realization
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //use repo from constructor
            var orderItem = await this._orderItemService.GetAllAsync();

            //returns Orders in OK request 
            return this.Ok(orderItem);
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] OrderItemModel orderItemModel)
        {
            var dbContext = new MenuDataContext();
            dbContext.Add(new OrderItem()
            {
                //OrderItemId = orderItemModel.OrderItemId,
                Order = orderItemModel.Order,
                //OrderId = orderItemModel.OrderId,
                Products = orderItemModel.Products
                //ProductId = orderItemModel.ProductId

            });
            dbContext.SaveChanges();

            return this.Ok();
        }

        [HttpPut("{id:int}/edit")]
        public async Task<IActionResult> Update([FromBody] OrderItemModel orderItemModel, [FromRoute] int id)
        {
            //var dbContext = new MenuDataContext();
            //var result = dbContext.Update(Orders);

            var orderItem = this._mapper.Map<OrderItem>(orderItemModel);
            await this._orderItemService.TryUpdateAsync(id, orderItem);

            return this.Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var orderItem = await this._orderItemService.GetByIdAsync(id);
            if (orderItem == null)
            {
                return this.NotFound();
            }

            return this.Ok(orderItem);
        }

        [HttpDelete("{id:int}/delete")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var orderItem = await this._orderItemService.GetByIdAsync(id);
            if (orderItem != null)
            {
                await this._orderItemService.DeleteAsync(orderItem);
                return this.Ok();
            }
            return this.NotFound();
        }
    }
}