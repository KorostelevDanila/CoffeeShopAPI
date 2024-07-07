namespace CoffeeShopAPI.DTO
{
    public record class UpdateProductDto(
        string Name,
        decimal Price,
        int Volume,
        string Description,
        int CategoryId
    );
}
