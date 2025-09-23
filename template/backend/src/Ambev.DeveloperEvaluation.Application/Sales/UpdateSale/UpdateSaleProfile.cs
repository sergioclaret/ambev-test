using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Services.Static;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleProfile : Profile
    {
        public UpdateSaleProfile()
        {
            CreateMap<UpdateSaleCommand, Sale>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
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

            CreateMap<UpdateProductCommand, Product>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.SaleId, opt => opt.Ignore())
                .ForMember(dest => dest.OriginalTotalPrice,
                    opt => opt.MapFrom((src, dest) => ProductStaticService.CalculateOriginalPrice(src.Quantity, src.UnitPrice)))
                .ForMember(dest => dest.DiscountPercentual,
                    opt => opt.MapFrom((src, dest) => ProductStaticService.CalculateDiscountPercentual(src.Quantity, src.UnitPrice)))
                .ForMember(dest => dest.DiscountValue,
                    opt => opt.MapFrom((src, dest) => ProductStaticService.CalculateDiscountValue(src.Quantity, src.UnitPrice)))
                .ForMember(dest => dest.TotalAmount,
                    opt => opt.MapFrom((src, dest) => ProductStaticService.CalculateFinalPrice(src.Quantity, src.UnitPrice)));

        }
    }
}
