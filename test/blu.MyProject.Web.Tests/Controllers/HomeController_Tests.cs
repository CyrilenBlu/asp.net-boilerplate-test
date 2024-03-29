﻿using System.Threading.Tasks;
using blu.MyProject.Web.Controllers;
using Shouldly;
using Xunit;

namespace blu.MyProject.Web.Tests.Controllers
{
    public class HomeController_Tests: MyProjectWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
