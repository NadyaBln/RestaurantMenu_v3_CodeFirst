using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantMenu_v3_CodeFirst.BusinessLogic_Services;
using RestaurantMenu_v3_CodeFirst.Entities;
using RestaurantMenu_v3_CodeFirst.Models;
using System.Threading.Tasks;

namespace RestaurantMenu_v3_CodeFirst.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        //to use automapper we should use it as dependency
        private readonly IMapper _mapper;

        //and use Interface - Interface moves us to abstraction
        //add BL layer, that's why use ProductService
        private readonly IProductService _productService;

        //initialization via constructor
        public ProductController(IProductService productService, IMapper mapper)
        {
            this._productService = productService;
            this._mapper = mapper;
        }




        //controller methods realization
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //use repo from constructor
            var product = await this._productService.GetAllAsync();

            //returns product in OK request 
            return this.Ok(product);
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ProductModel productModel)
        {
            var dbContext = new MenuDataContext();
            dbContext.Add(new Product()
            {
                //ProductId = productModel.ProductId,
                Title = productModel.Title,
                Calories = productModel.Calories,
                Description = productModel.Description,
                Price = productModel.Price,
                CategoryId = productModel.CategoryId,
                IsAlcohol = productModel.IsAlcohol,
                IsSeason = productModel.IsSeason,
                IsActive = productModel.IsActive,
                AllergenId = productModel.AllergenId

            });
            dbContext.SaveChanges();

            return this.Ok();
        }

        [HttpPut("{id:int}/edit")]
        public async Task<IActionResult> Update([FromBody] ProductModel productModel, [FromRoute] int id)
        {
            //var dbContext = new MenuDataContext();
            //var result = dbContext.Update(product);

            var product = this._mapper.Map<Product>(productModel);
            await this._productService.TryUpdateAsync(id, product);

            return this.Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await this._productService.GetByIdAsync(id);
            if (product == null)
            {
                return this.NotFound();
            }

            return this.Ok(product);
        }

        [HttpDelete("{id:int}/delete")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var product = await this._productService.GetByIdAsync(id);
            if (product != null)
            {
                await this._productService.DeleteAsync(product);
                return this.Ok();
            }
            return this.NotFound();
        }
    }
}