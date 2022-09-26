using Autofac;
using RestaurantMenu_v3_CodeFirst.BusinessLogic_Services;
using RestaurantMenu_v3_CodeFirst.DataAccess;

namespace RestaurantMenu_v3_CodeFirst.BusinessLogic
{
    public class BLRegistrationModule : Module
    {
        //there are registrations with dependence from DA
        //instead of registrations in Startup
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<DataAccessRegistrationModule>();
            builder.RegisterType<OrderService>().As<IOrderService>();
            builder.RegisterType<OrderItemService>().As<IOrderItemService>();
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<GuestService>().As<IGuestService>();
        }
    }
}
