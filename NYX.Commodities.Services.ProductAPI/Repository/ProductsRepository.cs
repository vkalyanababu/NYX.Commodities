using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NYX.Commodities.Services.ProductAPI.Data;
using NYX.Commodities.Services.ProductAPI.Models;
using NYX.Commodities.Services.ProductAPI.Models.Dtos;
using System;
using System.Drawing;

namespace NYX.Commodities.Services.ProductAPI.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ProductDBContext _dbContext;
        private IMapper _mapper;
        private readonly ILogger<ProductsRepository> _logger;
        public ProductsRepository(ProductDBContext dbContext, IMapper mapper, ILogger<ProductsRepository> logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<Product> GetProductByColorAsync(string color)
        {
            try
            {
                if(string.IsNullOrEmpty(color))
                    throw new ArgumentNullException(nameof(color));

                var product = await _dbContext.Products.FirstAsync(p => p.ProductColor == color).ConfigureAwait(false);
                if (product != null)
                {
                    return _mapper.Map<Product>(product);
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call GetProductByColor in repo class, Error Message = {ex}.");
                throw;
            }
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            try
            {
                var products = await _dbContext.Products.ToListAsync();
                if (products != null)
                {
                    return _mapper.Map<IEnumerable<Product>>(products);
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while trying to call GetProductsAsync in repo class, Error Message = {ex}.");
                throw;
            }
        }
    }
}
