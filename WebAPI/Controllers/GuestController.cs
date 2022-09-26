using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantMenu_v3_CodeFirst.BusinessLogic_Services;
using RestaurantMenu_v3_CodeFirst.Entities;
using RestaurantMenu_v3_CodeFirst.Models;
using System.Threading.Tasks;

namespace RestaurantMenu_v3_CodeFirst.Controllers
  {
    [ApiController]
    [Route("guest")]
    public class GuestController : ControllerBase
    {
        //to use automapper we should use it as dependency
        private readonly IMapper _mapper;

        //and use Interface - Interface moves us to abstraction
        //add BL layer, that's why use GuestService
        private readonly IGuestService _guestService;

        //initialization via constructor
        public GuestController(IGuestService guestService, IMapper mapper)
        {
            this._guestService = guestService;
            this._mapper = mapper;
        }

        //controller methods realization
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //use repo from constructor
            var guest = await this._guestService.GetAllAsync();
            return this.Ok(guest);
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] GuestModel guestModel)
        {
            var dbContext = new MenuDataContext();
            dbContext.Add(new Guest()
            {
                //GuestId = guestModel.GuestId,
                GuestName = guestModel.GuestName,
                GuestEmail = guestModel.GuestEmail,
                IsAdmin = guestModel.IsAdmin
            });
            dbContext.SaveChanges();

            return this.Ok();
        }

        [HttpPut("{id:int}/edit")]
        public async Task<IActionResult> Update([FromBody] GuestModel guestModel, [FromRoute] int id)
        {
            var guest = this._mapper.Map<Guest>(guestModel);
            await this._guestService.TryUpdateAsync(id, guest);

            return this.Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var guest = await this._guestService.GetByIdAsync(id);
            if (guest == null)
            {
                return this.NotFound();
            }

            return this.Ok(guest);
        }

        //[HttpDelete("{id:int}/delete")]
        //public async Task<IActionResult> Delete([FromRoute] int id)
        //{
        //    var guest = await this._guestService.GetByIdAsync(id);
        //    if (guest != null)
        //    {
        //        await this._guestService.DeleteAsync(guest);
        //        return this.Ok();
        //    }
        //    return this.NotFound();
        //}
    }

}
