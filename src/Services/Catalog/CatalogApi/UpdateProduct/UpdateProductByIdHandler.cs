using BuildingBlocks.CQRS;
using CatalogApi.Exceptions;
using CatalogApi.Model;
using Microsoft.Extensions.Logging;

namespace CatalogApi.UpdateProduct
{
    public record UpdateProductByIdCommand(Guid Id, string Name, string Description, decimal Price)
        : ICommand<UpdateProductByIdResult>;

    public record UpdateProductByIdResult(bool IsSuccess);
    public class UpdateProductByIdHandler(IDocumentSession session, ILogger<UpdateProductByIdCommand> logger)
        : ICommandHandler<UpdateProductByIdCommand, UpdateProductByIdResult>
    {
        public async Task<UpdateProductByIdResult> Handle(UpdateProductByIdCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("UpdateProductById Handler");
            var product = await session.LoadAsync<Product>(command.Id, cancellationToken);
            if (product == null)
            {
                logger.LogWarning("Product with ID {Id} not found", command.Id);
                throw new ProdcutNotFoundException();
            }
            product.Name = command.Name;
            product.Description = command.Description;
            product.Price = command.Price;
            session.Update(product);
            await session.SaveChangesAsync(cancellationToken);
            logger.LogInformation("Product with ID {Id} updated successfully", command.Id);
            return new UpdateProductByIdResult(true);
        }
    }
}
