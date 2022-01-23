using DAW_Project.Data;
using DAW_Project.Models;
using DAW_Project.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Repositories.ProductRepository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly DAW_ProjectContext _context;

        public ProductRepository(DAW_ProjectContext context) : base(context)
        {
            _context = context;
        }

        public List<Product> GetAllProducts()
        {
            return new List<Product>(_context.Products.AsNoTracking().ToList());

        }

        public Product GetByName(string name)
        {
            return _context.Products.FirstOrDefault(p => p.Name.Equals(name));
        }
    }
}
