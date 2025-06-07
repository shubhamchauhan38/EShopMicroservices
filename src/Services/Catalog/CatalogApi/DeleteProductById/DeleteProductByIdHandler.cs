using BuildingBlocks.CQRS;
using CatalogApi.Model;

namespace CatalogApi.DeleteProductById
{
    public record DeleteProductByIdCommand(Guid Id) : ICommand<DeleteProductByIdResult>;

    public record DeleteProductByIdResult(bool IsSuccess);
    public class DeleteProductByIdHandler(IDocumentSession session, ILogger<DeleteProductByIdCommand> logger)
        : ICommandHandler<DeleteProductByIdCommand, DeleteProductByIdResult>
    {
        public async Task<DeleteProductByIdResult> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("DeleteProductById Handler");
            var product = await session.LoadAsync<Product>(command.Id,cancellationToken);
            if (product == null)
            {
                logger.LogWarning("Product with ID {Id} not found", command.Id);
                return new DeleteProductByIdResult(false);
            }
            session.Delete(product);
            await session.SaveChangesAsync(cancellationToken);
            logger.LogInformation("Product with ID {Id} deleted successfully", command.Id);
            return new DeleteProductByIdResult(true);
        }
    }
}
