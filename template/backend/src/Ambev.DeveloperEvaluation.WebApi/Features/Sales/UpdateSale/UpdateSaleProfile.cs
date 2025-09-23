using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateSaleProfile : Profile
    {
        public UpdateSaleProfile()
        {
            CreateMap<UpdateSaleRequest, UpdateSaleCommand>();
            CreateMap<UpdateProductRequest, UpdateProductCommand>();
            CreateMap<UpdateSaleCommand, Sale>();
            CreateMap<UpdateProductCommand, Product>();
            CreateMap<Sale, UpdateSaleResult>();
            CreateMap<Product, UpdateProductResult>();
            CreateMap<UpdateSaleResult, UpdateSaleResponse>();
            CreateMap<UpdateProductResult, UpdateProductResponse>();
        }
    }
}
