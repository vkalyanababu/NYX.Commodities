using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NYX.Commodities.Services.ProductAPI.Data;
using NYX.Commodities.Services.ProductAPI.Models;
using NYX.Commodities.Services.ProductAPI.Models.Dtos;
using NYX.Commodities.Services.ProductAPI.Repository;
using static System.Net.Mime.MediaTypeNames;

namespace NYX.Commodities.Services.ProductAPI.Controllers
{
    [Route("api/products")]
    [Produces(Application.Json)]
    [ApiController]
    [Authorize]
    public class ProductAPIController : ControllerBase
    {
        private readonly IProductsRepository _productsRepository;

        public ProductAPIController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Product>> Get()
        {
            var response = await _productsRepository.GetProductsAsync();
            return response != null ? Ok(response) : NotFound();
        }

        [HttpGet]
        [Route("{color:alpha}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Product>>> GetByColor(string color)
        {
            if (string.IsNullOrEmpty(color))
                return BadRequest();

            var response = await _productsRepository.GetProductByColorAsync(color);
            return response != null ? Ok(response) : NotFound();
        }
    }
}
