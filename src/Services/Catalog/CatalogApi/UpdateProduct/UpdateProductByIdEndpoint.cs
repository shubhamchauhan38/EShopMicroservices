using BuildingBlocks.CQRS;

namespace CatalogApi.UpdateProduct
{
    public record UpdateProductByIdRequest(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price) 
        : ICommand<UpdateProductByResponse>;

    public record UpdateProductByResponse(bool IsSuccess);
    public class UpdateProductByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            _ = app.MapPut("/products/{id:guid}",
                               async (Guid id, UpdateProductByIdCommand command, ISender sender) =>
                               {
                                   if (id != command.Id)
                                   {
                                       return Results.BadRequest("Product ID in the URL does not match the ID in the request body.");
                                   }

                                   var result = await sender.Send(command);
                                   if (result.IsSuccess)
                                   {
                                       return Results.Ok(result);
                                   }
                                   return Results.NotFound();
                               })
                 .WithName("UpdateProductById")
                 .WithSummary("Update an existing product by ID")
                 .WithDescription("Updates the details of an existing product in the catalog.")
                 .Produces<UpdateProductByResponse>(StatusCodes.Status200OK)
                 .Produces(StatusCodes.Status404NotFound)
                 .Produces(StatusCodes.Status400BadRequest);
        }
    }
}
