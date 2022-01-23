using DAW_Project.Data;
using DAW_Project.DTOs;
using DAW_Project.Models;
using DAW_Project.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly DAW_ProjectContext _context;

        public CategoryController(ICategoryService categoryService, DAW_ProjectContext context)
        {
            _categoryService = categoryService;
            _context = context;
        }

        //GET
        [HttpGet("byId")]
        public IActionResult GetById(Guid Id)
        {
            return Ok(_categoryService.GetCategoryByCategoryId(Id));
        }


        [HttpGet("allCategories")]
        public IActionResult GetAllCategories()
        {
            return Ok(_categoryService.GetAllCategories());
        }


        //POST
        [HttpPost("create")]
        public IActionResult Create(RegisterCategoryDTO category)
        {
            _categoryService.CreateCategory(category);
            return Ok();
        }

        //PUT
        [HttpPut("update")]
        public IActionResult Update(Category category, Guid id)
        {
            _categoryService.UpdateCategory(category, id);
            return Ok();
        }


        //DELETE
        [HttpDelete]
        public IActionResult DeleteById(Guid Id)
        {
            _categoryService.DeleteCategoryById(Id);
            return Ok();
        }
    }
}
