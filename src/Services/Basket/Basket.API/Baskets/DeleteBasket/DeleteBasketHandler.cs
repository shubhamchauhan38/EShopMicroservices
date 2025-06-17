namespace Basket.API.Baskets.DeleteBasket
{
    public record DeleteBasketCommand(string UserName) : ICommand<DeleteBasketResult>;

    public record DeleteBasketResult(Boolean IsSuccess);
    
    public class DeleteBasketHandler : ICommandHandler<DeleteBasketCommand, DeleteBasketResult>
    {
        public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command, CancellationToken cancellationToken)
        {
            // Here you would typically delete the basket from a database or cache.
            return new DeleteBasketResult(true);
        }
    }   
}
