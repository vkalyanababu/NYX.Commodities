using NYX.Commodities.Services.ProductAPI.Models;
using NYX.Commodities.Services.ProductAPI.Models.Dtos;

namespace NYX.Commodities.Services.ProductAPI.Repository
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByColorAsync(string color);
    }
}
