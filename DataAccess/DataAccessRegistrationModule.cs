using Autofac;
using RestaurantMenu_v3_CodeFirst.DataAccess.Repositories;

namespace RestaurantMenu_v3_CodeFirst.DataAccess
{
    public class DataAccessRegistrationModule : Module
    {
        //there are registrations for DB (DA)
        //instead of registrations in Startup
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MenuDataContext>().AsSelf();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<OrderItemRepository>().As<IOrderItemRepository>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();
            builder.RegisterType<GuestRepository>().As<IGuestRepository>();
        }
    }
}