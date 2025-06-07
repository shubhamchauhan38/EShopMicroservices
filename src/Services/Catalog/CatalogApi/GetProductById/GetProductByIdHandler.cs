using BuildingBlocks.CQRS;
using CatalogApi.Exceptions;
using CatalogApi.Model;

namespace CatalogApi.GetProductById
{
    public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;

    public record GetProductByIdResult(Product Product);
    public class GetProductByIdHandler(IDocumentSession session,ILogger<GetProductByIdHandler> logger)
        : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductById Handler");
            var product = await session.LoadAsync<Product>(query.Id,cancellationToken);
            if(product == null)
            {
                throw new ProdcutNotFoundException();
            }
            return new GetProductByIdResult(product);
        }
    }
}
