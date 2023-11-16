using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyStore.Controllers;
using MyStore.Data;
using MyStore.Domain;
using MyStore.Services;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Tests.Unit
{
    public class CategoriesControllerTests
    {
        private readonly ICategoryService subjectUnderTest;
        private readonly ICategoryRepository mockRepository;

        public CategoriesControllerTests()
        {
            mockRepository = Substitute.For<ICategoryRepository>();

            subjectUnderTest = new CategoryService(mockRepository);

        }

        [Fact]
        public void GetCategoryShouldReturn_Category_WhenExists()
        {
            // arrange 
            var existingCategory = new Category()
            {
                Categoryid = 1,
                Categoryname = "Test CategoryName",
                Description = "Test Category Description",
            };

            mockRepository
                .GetCategoryById(existingCategory.Categoryid)
                .Returns(existingCategory);

            // act

            var actualResult=subjectUnderTest.GetCategory(existingCategory.Categoryid); 

            //assert
            actualResult.Should().BeEquivalentTo(existingCategory);
        }


     }

        


    
}
