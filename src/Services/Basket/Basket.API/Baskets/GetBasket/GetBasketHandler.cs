using Basket.API.Models;
using BuildingBlocks.CQRS;

namespace Basket.API.Baskets.GetBasket
{
    public record GetBasketQuery(string UserName) : IQuery<GetBasketResult>;

    public record GetBasketResult(ShoppingCart Cart);
    public class GetBasketQueryHandle : IQueryHandler<GetBasketQuery, GetBasketResult>
    {
        public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
        {
            return new GetBasketResult(new ShoppingCart
            {
                UserName = query.UserName,
                Items = new List<ShoppingCartItem>
                {
                    new ShoppingCartItem
                    {
                        ProductId = Guid.NewGuid(),
                        ProductName = "Sample Product",
                        Price = 10.99m,
                        Quantity = 1
                    }
                }
            });
        }
    }
}
