using Basket.API.Models;

namespace Basket.API.Basket.DeleteBasket
{
    public record GetBasketQuery(string userName);
    public record GetBasketResult(ShoppingCart Cart);

    public class DeleteBasketHandler
    {
    }
}
