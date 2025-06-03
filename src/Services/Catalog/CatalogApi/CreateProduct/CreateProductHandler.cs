using BuildingBlocks.CQRS;
using CatalogApi.Model;


namespace CatalogApi.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
        :ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);

    internal class CreateProductHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            // Create Product entity from command object

            // Save to database

            // return CreateProductresult result
            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price
            };
            //throw new NotImplementedException();

            return new CreateProductResult(Guid.NewGuid()); // Simulating a new product ID after creation

        }
    }
}
