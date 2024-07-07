using CoffeeShopAPI.Models;

namespace CoffeeShopAPI.DTO
{
    public record class ProductSummaryDto(
        int Id,
        string Name,
        decimal Price,
        int Volume,
        string Description,
        string Category
        );
}
