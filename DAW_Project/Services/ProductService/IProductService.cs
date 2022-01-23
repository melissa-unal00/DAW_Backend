using DAW_Project.DTOs;
using DAW_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Services.ProductService
{
    public interface IProductService
    {
        public List<RespondProductDTO> GetAllProducts();

        RespondProductDTO GetProductByProductId(Guid Id);

        void CreateProduct(RegisterProductDTO entity);

        void DeleteProductById(Guid id);

        void UpdateProduct(Product product, Guid id);
    }
}
