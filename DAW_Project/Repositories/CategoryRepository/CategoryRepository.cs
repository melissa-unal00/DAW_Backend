using DAW_Project.Data;
using DAW_Project.Models;
using DAW_Project.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Repositories.CategoryRepository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly DAW_ProjectContext _context;

        public CategoryRepository(DAW_ProjectContext context) : base(context)
        {
            _context = context;
        }

        public List<Category> GetAllCategories()
        {
            return new List<Category>(_context.Categories.AsNoTracking().ToList());
        }

        public Category GetByName(string name)
        {
            return _context.Categories.FirstOrDefault(c => c.Name.Equals(name));
        }
    }
}
