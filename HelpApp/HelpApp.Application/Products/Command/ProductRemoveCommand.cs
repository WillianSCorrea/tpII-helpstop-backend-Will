using MediatR;
using HelpApp.Domain.Entities;

namespace HelpApp.Application.Products.Command
{
    public class ProductRemoveCommand : IRequest<Product>
    {
        public int Id { get; set; }

    }

}
