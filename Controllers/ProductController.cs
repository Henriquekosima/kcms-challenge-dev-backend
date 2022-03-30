using kcms_challenge_dev_backend.InputModels;
using kcms_challenge_dev_backend.Models.Collections;
using kcms_challenge_dev_backend.Services.Interfaces;
using kcms_challenge_dev_backend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kcms_challenge_dev_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductInputModel ProductInputModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = await _productService.CreateAsync(ProductInputModel);

                return Ok((ProductViewModel)result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("ListProductsByCategory/{CategoryID}")]
        public async Task<IActionResult> ListProductsByCategory(string CategoryID)
        {
            try
            {
                var result = await _productService.GetProductsByCategoryIdAsync(CategoryID);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result.Select(a => (ProductViewModel)a));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("{ProductID}")]
        public async Task<IActionResult> Get(string ProductID)
        {
            try
            {
                var result = await _productService.GetByIdAsync(ProductID);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok((ProductViewModel)result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{ProductID}")]
        public async Task<IActionResult> Delete(string ProductID)
        {
            try
            {
                var result = await _productService.GetByIdAsync(ProductID);

                if (result == null)
                {
                    return NotFound();
                }

                await _productService.DeleteAsync(result.ProductID);

                return NoContent();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("{ProductID}")]
        public async Task<IActionResult> Update(string ProductID, string NewCategoryID)
        {
            try
            {
                var result = await _productService.GetByIdAsync(ProductID);

                if (result == null)
                {
                    return NotFound();
                }

                await _productService.UpdateAsync(ProductID, NewCategoryID);

                return NoContent();
            }
            catch (Exception ex) 
            { 
                throw ex;
            }
        }
    }
}
