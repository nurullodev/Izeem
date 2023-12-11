using Izeem.API.Middlewares;
using Izeem.DAL.IRepositories;
using Izeem.DAL.Repositories;
using Izeem.Service.Interfaces.Addresses;
using Izeem.Service.Interfaces.Assets;
using Izeem.Service.Interfaces.Carts;
using Izeem.Service.Interfaces.Orders;
using Izeem.Service.Interfaces.Payments;
using Izeem.Service.Interfaces.Products;
using Izeem.Service.Interfaces.Users;
using Izeem.Service.Interfaces.Vehicles;
using Izeem.Service.Mappers;
using Izeem.Service.Services.Addresses;
using Izeem.Service.Services.Assets;
using Izeem.Service.Services.Carts;
using Izeem.Service.Services.Orders;
using Izeem.Service.Services.Payments;
using Izeem.Service.Services.Products;
using Izeem.Service.Services.Suppliers;
using Izeem.Service.Services.Users;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Newtonsoft.Json;

namespace Izeem.API.Extensions;

public static class ServiceExtension
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        //SlugParameterTransformer make upper case to lower case
        services.AddControllers(options =>
        options.Conventions.Add(new RouteTokenTransformerConvention(new SlugParameterTransformer())));


        //Json serializer
        services.AddControllers().AddNewtonsoftJson(o =>
        {
            o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        });


        //Auto mapping Dependency Injection
        services.AddAutoMapper(typeof(MappingProfile));

        //Generic repository
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddHttpContextAccessor();

        #region Services

        //Auth
        //services.AddScoped<IAuthService, AuthService>();
        //services.AddScoped<IIdentityService, IdentityService>();
        //services.AddScoped<ITokenService, TokenService>();
        //services.AddScoped<ISmsSender, SmsSender>();

        //User
        services.AddScoped<IUserService, UserService>();

        //Addresses
        services.AddScoped<IAddressService, AddressService>();

        //Product category
        services.AddScoped<IProductCategoryService, ProductCategoryService>();
        services.AddScoped<IProductService, ProductService>();

        //Payment
        services.AddScoped<IPaymentService, PaymentService>();

        //Cart
        services.AddScoped<ICartService, CartService>();
        services.AddScoped<ICartItemService, CartItemService>();

        //Asset
        services.AddScoped<IAssetService, AssetService>();

        //Order
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IOrderItemService, OrderItemService>();

        //Supplier
        services.AddScoped<IVehicleService, VehicleService>();
        services.AddScoped<ISupplierService, SupplierService>();
        #endregion
    }
}
