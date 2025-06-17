namespace Basket.API.Baskets.DeleteBasket
{
    public record DeleteBasketResponse(Boolean IsSuccess);
    public class DeleteBasketEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/basket/{userName}", async (string userName, ISender sender) =>
            {
                var command = new DeleteBasketCommand(userName);
                var result = await sender.Send(command);
                return Results.Ok(new DeleteBasketResponse(true));
            })
                .WithName("DeleteBasket")
                .WithSummary("Delete a shopping cart for a user")
                .Produces<DeleteBasketResponse>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .Produces(StatusCodes.Status500InternalServerError);
        }
    }
}
