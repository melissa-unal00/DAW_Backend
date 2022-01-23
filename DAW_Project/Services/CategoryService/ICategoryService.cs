using DAW_Project.DTOs;
using DAW_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DAW_Project.Services.CategoryService
{
    public interface ICategoryService
    {
        public List<RespondCategoryDTO> GetAllCategories();

        RespondCategoryDTO GetCategoryByCategoryId(Guid Id);

        void CreateCategory(RegisterCategoryDTO entity);

        void DeleteCategoryById(Guid id);

        void UpdateCategory(Category category, Guid id);
    }
}
