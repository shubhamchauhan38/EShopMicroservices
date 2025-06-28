using BuildingBlocks.CQRS;
using CatalogApi.Model;

namespace CatalogApi.GetProduct
{
    public record GetProductQuery() : IQuery<GetProductsResult>;

    public record GetProductsResult(IEnumerable<Product> Products);

    internal class GetProductsQueryHandler(IDocumentSession session) 
        : IQueryHandler<GetProductQuery,GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductQuery query, CancellationToken cancellationToken)
        {
            //Logger.LogInformation("GetProductQueryHandler")
            var product = await session.Query<Product>().ToListAsync(cancellationToken);

            return new GetProductsResult([]);
        }
    }
}
