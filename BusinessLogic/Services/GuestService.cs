using RestaurantMenu_v3_CodeFirst.DataAccess.Repositories;
using RestaurantMenu_v3_CodeFirst.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantMenu_v3_CodeFirst.BusinessLogic_Services
{ //create interface
    public interface IGuestService
    {
        //add all methods from Controller
        //it is the same as in GuestRepository
        Task<ICollection<Guest>> GetAllAsync();
        Task AddAsync(Guest guest);
        Task UpdateAsync(Guest guest);
        Task<bool> TryUpdateAsync(int id, Guest guest);
        Task<Guest> GetByIdAsync(int id);
        //Task DeleteAsync(Guest guest);
    }
    public class GuestService : IGuestService
    {
        //reference to GuestRepository
        private readonly IGuestRepository _repository;

        //initialization via constructor
        public GuestService(IGuestRepository repository)
        {
            this._repository = repository;
        }

        //method calls method GetAllAsync from abstraction 
        public Task<ICollection<Guest>> GetAllAsync()
        {
            var guestFromRepository = this._repository.GetAllAsync();
            return guestFromRepository;
        }

        public Task AddAsync(Guest guest)
           => this._repository.AddAsync(guest);

        public Task UpdateAsync(Guest guest)

            => this._repository.UpdateAsync(guest);

        public Task<Guest> GetByIdAsync(int id)
           => this._repository.GetByIdAsync(id);

        public async Task<bool> TryUpdateAsync(int id, Guest guest)
        {
            var guestToUpdate = await this._repository.GetByIdAsync(id);
            if (guestToUpdate != null)
            {
                guestToUpdate.GuestId = guest.GuestId;
                guestToUpdate.GuestEmail = guest.GuestEmail;
                guestToUpdate.GuestName = guest.GuestName;

                await this._repository.UpdateAsync(guestToUpdate);

                return true;
            }
            return false;
        }

        //public Task DeleteAsync(Guest guest)
        //    => this._repository.DeleteAsync(guest);
    }
}