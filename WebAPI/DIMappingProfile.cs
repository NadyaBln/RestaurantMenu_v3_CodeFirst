using AutoMapper;
using RestaurantMenu_v3_CodeFirst.Entities;
using RestaurantMenu_v3_CodeFirst.Models;

namespace RestaurantMenu_v3_CodeFirst.WebAPI
{
    public class DIMappingProfile : Profile
    {
        //create profile to add it to startup file
        public DIMappingProfile()
        {
            this.CreateMap<Order, OrderModel>();
            this.CreateMap<OrderModel, Order>();

            this.CreateMap<Product, ProductModel>();
            this.CreateMap<ProductModel, Product>();

            this.CreateMap<Guest, GuestModel>();
            this.CreateMap<GuestModel, Guest>();

            this.CreateMap<OrderItem, OrderItemModel>();
            this.CreateMap<OrderItemModel, OrderItem>();
        }
    }
}
