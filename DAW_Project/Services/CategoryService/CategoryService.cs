using AutoMapper;
using DAW_Project.DTOs;
using DAW_Project.Models;
using DAW_Project.Repositories.CategoryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW_Project.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        public ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public List<RespondCategoryDTO> GetAllCategories()
        {
            List<Category> categoriesList = _categoryRepository.GetAllCategories();
            List<RespondCategoryDTO> categoryRespondDTO = _mapper.Map<List<RespondCategoryDTO>>(categoriesList);
            return categoryRespondDTO;
        }

        public RespondCategoryDTO GetCategoryByCategoryId(Guid Id)
        {
            Category category = _categoryRepository.FindById(Id);
            RespondCategoryDTO categoryRespondDTO = _mapper.Map<RespondCategoryDTO>(category);
            return categoryRespondDTO;
        }

        public void CreateCategory(RegisterCategoryDTO entity)
        {
            if (_categoryRepository.GetByName(entity.Name) != null)
                throw new Exception("Category already exists");

            var categoryToCreate = _mapper.Map<Category>(entity);
            categoryToCreate.DateCreated = DateTime.Now;
            categoryToCreate.DateModified = DateTime.Now;


            _categoryRepository.Create(categoryToCreate);
            _categoryRepository.Save();
        }

        public void DeleteCategoryById(Guid id)
        {
            Category category = _categoryRepository.FindById(id);
            _categoryRepository.Delete(category);
            _categoryRepository.Save();
        }

        public void UpdateCategory(Category category, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
