
namespace Catalog.Products.Features.UpdateProduct
{
    public record UpdateProductCommand(ProductDto ProductDto)
        : ICommand<UpdateProductResult>;

    public record UpdateProductResult(bool IsSuccess);

    internal class UpdateProductHandler(CatalogDbContext dbContext)
        : ICommandHandler<UpdateProductCommand, UpdateProductResult>
    {
        public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            // Update Prodct entity from command object
            // save to database
            // return the result

            var product = await dbContext.Products
                .FindAsync([command.ProductDto.Id], cancellationToken: cancellationToken);

            if (product is null )
            {
                throw new Exception($"Product not found: {command.ProductDto.Id}");
            }

            UpdateProductWithNewValues(product, command.ProductDto);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new UpdateProductResult(true);
        }

        private void UpdateProductWithNewValues(Product product, ProductDto productDto)
        {
            product.Update(
                productDto.Name,
                productDto.Category,
                productDto.Description,
                productDto.ImageFile,
                productDto.Price
            );
        }
    }
}
