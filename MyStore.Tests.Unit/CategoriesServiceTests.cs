using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using MyStore.Data;
using MyStore.Domain;
using MyStore.Services;
using NSubstitute;

namespace MyStore.Tests.Unit
{
    public class CategoriesServiceTests
    {
        public readonly ICategoryService subjectUnderTest;
        public readonly ICategoryRepository mockRepository;

        public List<Category> categories;
        public CategoriesServiceTests() 
        {
            mockRepository = Substitute.For<ICategoryRepository>();
            subjectUnderTest = new CategoryService(mockRepository);
           
        }

        [Fact]

        public void GetCategory_ShouldReturn_Category_WhenExists()
        {
            // AAA

            // Arrange 

            var existingCategory = new Category()
            { 
                Categoryid= 1,
                Categoryname = "Test category",
                Description = "Test description",
            };

            mockRepository.GetCategoryById(existingCategory.Categoryid).Returns(existingCategory);


            // Act 
            var actualResult = subjectUnderTest.GetCategory(existingCategory.Categoryid);   

            // Assert 
            actualResult.Should().BeEquivalentTo(existingCategory);

        }
        //public bool IsDuplicate(string Categoryname)
        //{
        //    var categories = categoryRepository.GetAll();//1
        //    categories = categories.Where(x => x.Categoryname == Categoryname);//2
        //    categories.Where(x => x.Description.Contains("a"));//3
        //    //.ToList(); // loaded in memory

        //    return categories.Any();
        //}



        [Fact]
        public void IsDuplicate_ShouldReturnTrue_WhenCategoryName_Exists()
        {
            // Arrange 
            var categoryToSearch = "fructe";

            var categoryList = new List<Category>()
            {
                 new Category()
                 {
                Categoryid= 1,
                Categoryname = "Test category",
                Description = "Test description",

                 },
                 new Category()
                 {
                Categoryid= 3,
                Categoryname = "fructe",
                Description = "Test description",
                 }

            };

            mockRepository.GetAll().Returns(categoryList.AsQueryable());    
            // Act 

            var actualResult = subjectUnderTest.IsDuplicate(categoryToSearch);

            // Assert 

            actualResult.Should().BeTrue();

        }

        [Fact]
        public void IsDuplicate_ShouldReturnFalse_WhenCategoryName_DoesntExists()
        {
            // Arrange 
            var categoryToSearch = "fructisoare";

            var categoryList = new List<Category>()
            {
                 new Category()
                 {
                Categoryid= 1,
                Categoryname = "Test category",
                Description = "Test description",

                 },
                 new Category()
                 {
                Categoryid= 3,
                Categoryname = "fructe",
                Description = "Test description",
                 }

            };

            mockRepository.GetAll().Returns(categoryList.AsQueryable());
            // Act 

            var actualResult = subjectUnderTest.IsDuplicate(categoryToSearch);

            // Assert 

            actualResult.Should().BeFalse();

        }


    }
}
