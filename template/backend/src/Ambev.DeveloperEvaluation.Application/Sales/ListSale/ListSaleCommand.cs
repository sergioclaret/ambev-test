using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale
{
    public class ListSaleCommand : IRequest<List<ListSaleResult>>
    {
    }
}
