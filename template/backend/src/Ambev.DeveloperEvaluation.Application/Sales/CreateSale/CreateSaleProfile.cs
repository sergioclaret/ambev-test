using Ambev.DeveloperEvaluation.Application.Sales.ListSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Services.Static;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleProfile : Profile
    {
        public CreateSaleProfile()
        {
            CreateMap<CreateSaleCommand, Sale>()
                .ForMember(dest => dest.OriginalTotalPrice,
                    opt => opt.MapFrom((src, dest, _, ctx) =>
                    {
                        var products = ctx.Mapper.Map<List<Product>>(src.Products);
                        return SaleStaticService.CalculateOriginalPrice(products);
                    }))
                .ForMember(dest => dest.DiscountValue,
                    opt => opt.MapFrom((src, dest, _, ctx) =>
                    {
                        var products = ctx.Mapper.Map<List<Product>>(src.Products);
                        return SaleStaticService.CalculateDiscountValue(products);
                    }))
                .ForMember(dest => dest.TotalAmount,
                    opt => opt.MapFrom((src, dest, _, ctx) =>
                    {
                        var products = ctx.Mapper.Map<List<Product>>(src.Products);
                        return SaleStaticService.CalculateFinalPrice(products);
                    }));

            CreateMap<CreateProductCommand, Product>()
                .ForMember(dest => dest.OriginalTotalPrice,
                    opt => opt.MapFrom((src, dest) => ProductStaticService.CalculateOriginalPrice(src.Quantity, src.UnitPrice)))
                .ForMember(dest => dest.DiscountPercentual,
                    opt => opt.MapFrom((src, dest) => ProductStaticService.CalculateDiscountPercentual(src.Quantity, src.UnitPrice)))
                .ForMember(dest => dest.DiscountValue,
                    opt => opt.MapFrom((src, dest) => ProductStaticService.CalculateDiscountValue(src.Quantity, src.UnitPrice)))
                .ForMember(dest => dest.TotalAmount,
                    opt => opt.MapFrom((src, dest) => ProductStaticService.CalculateFinalPrice(src.Quantity, src.UnitPrice)));

            CreateMap<Sale, CreateSaleResult>();
            CreateMap<Sale, ListSaleResult>();
        }
    }
}
