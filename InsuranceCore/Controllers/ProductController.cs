using InsuranceCore.Models.Builders.Specifications;
using InsuranceCore.Models.DTOs.Product;
using InsuranceCore.Responses;
using InsuranceCore.Services.ProductService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceCore.Controllers
{
    /// <summary>
    /// Controller used to expose Category resources of the API.
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        /// <param name="ProductService"></param>

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Get list of Products.
        /// </summary>
        /// <remarks>
        /// Get list of Products. The endpoint uses pagination and sort. Filter(s) can be applied for research.
        /// </remarks>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(PageInsuranceResponse<GetProductDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProducts()
        {
            var data = await _productService.GetAllProducts();

            return Ok(new PageInsuranceResponse<GetProductDto>(data, 0, 0,
                await _productService.CountProductsWhere()));
        }

        /// <summary>
        /// Get a Product by giving its Id.
        /// </summary>
        /// <remarks>
        /// Get a Product by giving its Id.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GetProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _productService.GetProduct(id));
        }

        /// <summary>
        /// Add a Product.
        /// </summary>
        /// <remarks>
        /// Add a Product.
        /// </remarks>
        /// <param name="Product"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(GetProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> AddCategory(AddProductDto Product)
        {
            return Ok(await _productService.AddProduct(Product));
        }

        /// <summary>
        /// Update a Product.
        /// </summary>
        /// <remarks>
        /// Update a Product.
        /// </remarks>
        /// <param name="Product"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [AllowAnonymous]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UpdateCategory(UpdateProductDto Product)
        {
            if (await _productService.GetProduct(Product.Id) == null)
                return NotFound();
            await _productService.UpdateProduct(Product);
            return Ok();
        }

        /// <summary>
        /// Delete a Product by giving its id.
        /// </summary>
        /// <remarks>
        /// Delete a Product by giving its id.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (await _productService.GetProduct(id) == null)
                return NotFound();
            await _productService.DeleteProduct(id);
            return Ok();
        }
    }
}
