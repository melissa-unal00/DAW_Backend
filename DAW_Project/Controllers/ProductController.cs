using DAW_Project.Data;
using DAW_Project.DTOs;
using DAW_Project.Models;
using DAW_Project.Services.ProductService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly DAW_ProjectContext _context;

        public ProductController(IProductService productService, DAW_ProjectContext context)
        {
            _productService = productService;
            _context = context;
        }
        
        //GET
        [HttpGet("byId")]
        public IActionResult GetById(Guid Id)
        {
            return Ok(_productService.GetProductByProductId(Id));
        }
        
       
        [HttpGet("allProducts")]
        public IActionResult GetAllProducts() 
        {
            return Ok(_productService.GetAllProducts());
        }
        
        
        //POST
        [HttpPost("create")]
        public IActionResult Create(RegisterProductDTO product)
        {
            _productService.CreateProduct(product);
            return Ok();
        }
        
        //PUT
        [HttpPut("update")]
        public IActionResult Update(Product product, Guid id)
        {
            _productService.UpdateProduct(product,id);
            return Ok();
        }
        
        
        //DELETE
        [HttpDelete]
        public IActionResult DeleteById(Guid Id)
        {
            _productService.DeleteProductById(Id);
            return Ok();
        }
    }
}
