using Basket.API.Basket.DeleteBasket;
using Basket.API.Models;
using BuildingBlocks.CQRS;

namespace Basket.API.Basket.GetBasket
{
    public record GetBasketQuery(string userName) : IQuery<GetBasketResult>;
    public record GetBasketResult(ShoppingCart Cart);
    public class GetBasketHandler : IQueryHandler<GetBasketQuery, GetBasketResult>
    {
        public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
        {
            //TODO : Get Basket from the Repository
            //var basket = await _repository.GetBasketAsync(query.userName);

            return new GetBasketResult(new ShoppingCart("swn"));
        }
    }
}
