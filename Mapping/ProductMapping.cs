using CoffeeShopAPI.DTO;
using CoffeeShopAPI.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CoffeeShopAPI.Mapping
{
    public static class ProductMapping
    {
        public static Product ToEntity(this CreateProductDto productDto)
        {
            return new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Volume = productDto.Volume,
                Description = productDto.Description,
                CategoryId = productDto.CategoryId,
            };
        }

        public static Product ToEntity(this UpdateProductDto productDto, int id)
        {
            return new Product
            {
                Id = id,
                Name = productDto.Name,
                Price = productDto.Price,
                Volume = productDto.Volume,
                Description = productDto.Description,
                CategoryId = productDto.CategoryId,
            };
        }

        public static ProductSummaryDto ToSummaryDto(this Product product)
        {
            return new ProductSummaryDto
            (
                product.Id,
                product.Name,
                product.Price,
                product.Volume,
                product.Description,
                product.Category!.Name
            );
        }

        public static ProductDetailsDto ToDetailsDto(this Product product)
        {
            return new ProductDetailsDto
            (
                product.Id,
                product.Name,
                product.Price,
                product.Volume,
                product.Description,
                product.CategoryId
            );
        }
    }
}
