using Basket.API.Models;
using Carter;
using MediatR;

namespace Basket.API.Basket.GetBasket
{
    //public record GetBasketRequest(string userName);
    public record GetBasketResponse(ShoppingCart Cart);
    public class GetBasketEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/basket/{userName}", async (string userName, ISender sender) =>
            {
                var query = new GetBasketQuery(userName);
                var result = await sender.Send(query);
                var response = new GetBasketResponse(result.Cart);
                return Results.Ok(response);
            })
                .Produces<GetBasketResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithName("GetBasket")
                .WithSummary("GetBasket")
                .WithDescription("GetBasket");
        }
    }
}
