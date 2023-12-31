﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.Data;     
using MyStore.Domain;
using MyStore.Helpers;
using MyStore.Models;
using MyStore.Services;
using System.Linq;

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoriesController( ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IEnumerable<CategoryModel> Get(string? text, int page=1)
        {   // implementam paginarea unor rezultate 
            //2. adaugam un filtru de cautare in description dupa un nr de caracter
            // le ia pe toate 

            var allCategories = categoryService.GetCategories(page, text);

            // 1 2 -> 2(pagesize)*((3-paginaCurenta)-1))
            // filtrez si iau doar cele de afisat pe pagina curenta 
           // var currentPage = allCategories.Skip(pageSize*(pag-1)).Take(pageSize).ToList();

            var modelsToReturn = new List<CategoryModel>();
            foreach (var category in allCategories)
            {
                modelsToReturn.Add(category.ToCategoryModel());
            }

            return modelsToReturn;
        }


        // [HttpGet("mycoolCategory/{id:alpha}")]
        [HttpGet("{id}")]
        public ActionResult<CategoryModel> GetById(int id, CategoryModel model)
        {

            var categoryFromDb = categoryService.GetCategory(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            
            var categoryToUpdate = new Category();
            categoryToUpdate = model.ToCategory();
            categoryService.Update(categoryToUpdate);

            return Ok(categoryToUpdate.ToCategoryModel());
        }


        [HttpPut("{id}")]
        public ActionResult<CategoryModel> Update(int id, CategoryModel model)
        {
            //verificam in db daca avem ceva cu ID-ul respectiv
            // updatam
            // returnam 404

            var existingCategory = categoryService.GetCategory(id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            TryUpdateModelAsync(existingCategory);

            var categoryToUpdate = new Category();
            categoryToUpdate = model.ToCategory();
            categoryService.Update(categoryToUpdate);

            return Ok(categoryToUpdate.ToCategoryModel());
        }

        [HttpDelete("{id}")]
        public IActionResult Babu(int id)
        {
            var category = categoryService.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            //exista?
            //stergem
            categoryService.Remove(category);

            return NoContent();
        }

        [HttpPost]
        public IActionResult Create(CategoryModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: business rules

            if (categoryService.IsDuplicate(model.Categoryname))
            {
                ModelState.AddModelError("Categoryname", $"You can't have the same duplicate items with value{model.Categoryname}, on categoryName");
                return Conflict(ModelState);
            }
            //we need Category
            var categoryToSave = new Category();
            categoryToSave = model.ToCategory();

            categoryService.InsertNew(categoryToSave);

            model.Categoryid = categoryToSave.Categoryid;
            // return Ok(categoryToAdd);
            return CreatedAtAction(nameof(GetById), new { id = categoryToSave.Categoryid }, model);
        }
    }
}