using Catalog.API.Models;
using Catalog.API.Products.GetProductById;

namespace Catalog.API.Products.GetProductByCategory
{
    public record GetProductByCategoryResponse(IEnumerable<Product> Products);

    public class GetProductByCategoryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/category/{Category}", async (string Category, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByCategoryQuery(Category));

                var response = result.Adapt<GetProductByCategoryResponse>();

                return Results.Ok(response);
            })
.Produces<GetProductByCategoryResponse>(StatusCodes.Status200OK)
.ProducesProblem(StatusCodes.Status400BadRequest)
.WithName("GetProductByCategory")
.WithSummary("GetProductByCategory")
.WithDescription("GetProductByCategory");
        }
    }
}
