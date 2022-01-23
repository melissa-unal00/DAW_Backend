using AutoMapper;
using DAW_Project.DTOs;
using DAW_Project.Models;
using DAW_Project.Repositories.ProductRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Services.ProductService
{
    public class ProductService : IProductService
    {
        public IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public List<RespondProductDTO> GetAllProducts()
        {
            List<Product> productsList = _productRepository.GetAllProducts();
            List<RespondProductDTO> productRespondDto = _mapper.Map<List<RespondProductDTO>>(productsList);
            return productRespondDto;

        }

        public RespondProductDTO GetProductByProductId(Guid Id)
        {
            Product product = _productRepository.FindById(Id);
            RespondProductDTO productRespondDto = _mapper.Map<RespondProductDTO>(product);
            return productRespondDto;
        }

        public void CreateProduct(RegisterProductDTO entity)
        {
            // verific ca numele produsului sa fie unic
            if (_productRepository.GetByName(entity.Name) != null)
                throw new Exception("Product already exists");

            var productToCreate = _mapper.Map<Product>(entity);
            productToCreate.DateCreated = DateTime.Now;
            productToCreate.DateModified = DateTime.Now;


            _productRepository.Create(productToCreate);
            _productRepository.Save();
        }

        public void DeleteProductById(Guid id)
        {
            Product product = _productRepository.FindById(id);
            _productRepository.Delete(product);
            _productRepository.Save();
        }

        public void UpdateProduct(Product product, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
