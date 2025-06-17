using Basket.API.Models;

namespace Basket.API.Baskets.StoreBasket
{
    public record StoreBasketRequest(ShoppingCart Cart) : ICommand<StoreBasketResponse>;
    public record StoreBasketResponse(string UserName);

    public class StoreBasketEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/basket/{userName}", async (string userName, ISender sender) =>
            {
                var command = new StoreBasketRequest(new ShoppingCart { UserName = userName });
                var result = await sender.Send(command);
                return Results.Ok(new StoreBasketResponse(result.UserName));
            })
                .WithName("StoreBasket")
                .WithSummary("Store a shopping cart for a user")
                .Produces<StoreBasketResponse>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status500InternalServerError);
        }
    }
}
