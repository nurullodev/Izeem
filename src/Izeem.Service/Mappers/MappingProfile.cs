using AutoMapper;
using Izeem.Domain.Entities.Addresses;
using Izeem.Domain.Entities.Assets;
using Izeem.Domain.Entities.Orders;
using Izeem.Domain.Entities.Payments;
using Izeem.Domain.Entities.Products;
using Izeem.Domain.Entities.Suppliers;
using Izeem.Domain.Entities.Users;
using Izeem.Service.DTOs.Addresses;
using Izeem.Service.DTOs.Assets;
using Izeem.Service.DTOs.Orders;
using Izeem.Service.DTOs.Payments;
using Izeem.Service.DTOs.ProductCategories;
using Izeem.Service.DTOs.Products;
using Izeem.Service.DTOs.Suppliers;
using Izeem.Service.DTOs.Users;
using Izeem.Service.DTOs.Vehicles;

namespace Izeem.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Users
        CreateMap<User, UserResultDto>().ReverseMap();
        CreateMap<User, UserUpdateDto>().ReverseMap();
        CreateMap<User, UserCreationDto>().ReverseMap();
        CreateMap<User, UserRegisterDto>().ReverseMap();

        // User
        CreateMap<User, UserResultDto>().ReverseMap();
        CreateMap<UserCreationDto, User>().ReverseMap();
        CreateMap<UserUpdateDto, User>().ReverseMap();

        // Product
        CreateMap<Product, ProductResultDto>().ReverseMap();
        CreateMap<ProductCreationDto, Product>().ReverseMap();
        CreateMap<ProductUpdateDto, Product>().ReverseMap();

        // Product category
        CreateMap<ProductCategory, ProductCategoryResultDto>().ReverseMap();
        CreateMap<ProductCategoryCreationDto, ProductCategory>().ReverseMap();
        CreateMap<ProductCategoryUpdateDto, ProductCategory>().ReverseMap();

        // Attachment
        CreateMap<AssetResultDto, Asset>().ReverseMap();
        CreateMap<AssetCreationDto, Asset>().ReverseMap();

        //Vehicle
        CreateMap<Vehicle, VehicleResultDto>().ReverseMap();
        CreateMap<VehicleCreationDto, Vehicle>().ReverseMap();
        CreateMap<VehicleUpdateDto, Vehicle>().ReverseMap();

        //Address
        CreateMap<Address, AddressResultDto>().ReverseMap();
        CreateMap<AddressCreationDto, Address>().ReverseMap();
        CreateMap<AddressUpdateDto, Address>().ReverseMap();

        //Payment
        CreateMap<Payment, PaymentResultDto>().ReverseMap();
        CreateMap<PaymentCreationDto, Payment>().ReverseMap();
        CreateMap<PaymentUpdateDto, Payment>().ReverseMap();

        //Order
        CreateMap<Order, OrderResultDto>().ReverseMap();
        CreateMap<OrderCreationDto, Order>().ReverseMap();
        CreateMap<OrderUpdateDto, Order>().ReverseMap();

        CreateMap<OrderItem, OrderItemResultDto>().ReverseMap();
        CreateMap<OrderItemCreationDto, OrderItem>().ReverseMap();
        CreateMap<OrderItemUpdateDto, OrderItem>().ReverseMap();

        //Supplier
        CreateMap<Supplier, SupplierResultDto>().ReverseMap();
        CreateMap<SupplierCreationDto, Supplier>().ReverseMap();
        CreateMap<SupplierUpdateDto, Supplier>().ReverseMap();


    }
}