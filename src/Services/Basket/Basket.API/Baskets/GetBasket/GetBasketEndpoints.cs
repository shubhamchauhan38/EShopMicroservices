using Carter;

namespace Basket.API.Baskets.GetBasket 
{
    public record GetBasketResponse(string UserName);
    public class GetBasketEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/basket/{userName}", async (string userName, ISender sender) =>
            {
                var query = new GetBasketQuery(userName);
                var result = await sender.Send(query);
                return Results.Ok(new GetBasketResponse(result.Cart.UserName));
            })
                .WithName("GetBasket")
                .WithSummary("Get a shopping cart for a user")
                .Produces<GetBasketResponse>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .Produces(StatusCodes.Status500InternalServerError); 
        }
    }
}
