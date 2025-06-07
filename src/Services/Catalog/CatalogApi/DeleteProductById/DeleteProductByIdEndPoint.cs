using BuildingBlocks.CQRS;

namespace CatalogApi.DeleteProductById
{
    public record DeleteProductByIdRequest(Guid Id)
        :ICommand<DeleteProductByIdResult>;

    public record DeleteProductByIdResponse(bool IsSuccess);

    public class DeleteProductByIdEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
         {
            _ = app.MapDelete("/products/{id:guid}",
                               async (Guid id, ISender sender) =>
                               {
                                   var command = new DeleteProductByIdCommand(id);
                                   var result = await sender.Send(command);
                                   if (result.IsSuccess)
                                   {
                                       return Results.NoContent();
                                   }
                                   return Results.NotFound();
                               })
                .WithName("DeleteProductById")
                .WithSummary("Delete a product by ID")
                .WithDescription("Deletes a product from the catalog by its ID.")
                .Produces<DeleteProductByIdResult>(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound);
        }
    }       
}
