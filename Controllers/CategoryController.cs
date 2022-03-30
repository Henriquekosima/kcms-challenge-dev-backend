using kcms_challenge_dev_backend.InputModels;
using kcms_challenge_dev_backend.Models.Collections;
using kcms_challenge_dev_backend.Services.Interfaces;
using kcms_challenge_dev_backend.ViewModels;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Threading.Tasks;

namespace kcms_challenge_dev_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryInputModel CategoryInputModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = await _categoryService.CreateAsync(CategoryInputModel);

                return Ok((CategoryViewModel)result);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("{CategoryID}")]
        public async Task<IActionResult> Get(string CategoryID)
        {
            try 
            {
                var result = await _categoryService.GetByIDAsync(CategoryID);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok((CategoryViewModel)result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{CategoryID}")]
        public async Task<IActionResult> Delete(string CategoryID)
        {
            try
            {
                var result = await _categoryService.GetByIDAsync(CategoryID);

                if (result == null)
                {
                    return NotFound();
                }

                await _categoryService.DeleteAsync(result.CategoryID);

                return NoContent();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("{CategoryID}")]
        public async Task<IActionResult> Update(string CategoryID, [FromBody] CategoryInputModel CategoryInputModel)
        {
            try
            {
                var result = await _categoryService.GetByIDAsync(CategoryID);

                if (result == null)
                {
                    return NotFound();
                }

                await _categoryService.UpdateAsync(result.CategoryID, CategoryInputModel);

                return NoContent();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
