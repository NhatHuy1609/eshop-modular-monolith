using MediatR;

namespace Catalog.Products.Features.CreateProduct
{
    public record CreatepProductCommand
        (string Name, List<string> Category, string Description, string ImageFile, decimal Price)
        : IRequest<CreateProductResult>;

    public record CreateProductResult(Guid Id);

    internal class CreateProductCommandHandler : IRequestHandler<CreatepProductCommand, CreateProductResult>
    {
        public Task<CreateProductResult> Handle(CreatepProductCommand command, CancellationToken cancellationToken)
        {
            // Business logic to create a product
            throw new NotImplementedException();
        }
    }
}
