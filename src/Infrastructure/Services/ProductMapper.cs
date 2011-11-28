using System;
using Core.Domain;
using UI.Models;
using UI.Services;

namespace Infrastructure.Services
{
    public class ProductMapper : IProductVMMapper
    {
        public ProductInput Map(Product p)
        {
            return new ProductInput {ProductId = p.Id};
        }
    }
}