namespace CatalogApi.Exceptions
{
    public class ProdcutNotFoundException : Exception
    {
        public ProdcutNotFoundException()
            : base("Product not found.")
        {
        }

        public ProdcutNotFoundException(string message)
            : base(message)
        {
        }

        public ProdcutNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
