﻿namespace Catalog.Products.Features.CreateProduct
{
    public record CreateProductCommand(ProductDto ProductDto)
        : ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);

    internal class CreateProductHandler(CatalogDbContext dbContext)
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            // create Product entity from command object
            // save to database
            // return the result

            var product = CreateNewProduct(command.ProductDto);

            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreateProductResult(product.Id);
        }

        private Product CreateNewProduct(ProductDto productDto)
        {
            var product = Product.Create(
                productDto.Id,
                productDto.Name,
                productDto.Category,
                productDto.Description,
                productDto.ImageFile,
                productDto.Price
            );

            return product;
        }
    }
}
