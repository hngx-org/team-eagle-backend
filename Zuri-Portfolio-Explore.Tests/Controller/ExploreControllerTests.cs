using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Zuri_Portfolio_Explore.Controllers;
using Zuri_Portfolio_Explore.Domains.DTOs.Response;
using Zuri_Portfolio_Explore.Repository.Interfaces;

namespace Zuri_Portfolio_Explore.Tests.Controller
{
    public class ExploreControllerTests
    {
        private readonly IPortfolioService _portfolioService;

        public ExploreControllerTests()
        {
            _portfolioService = A.Fake<IPortfolioService>();
        }

        [Fact]
        public async void Explore_GetPortfolios_ReturnOk()
        {
            //Arrange
            var fPortfolioService = A.Fake<IPortfolioService>();
            var expectedResult = A.Fake<List<PortfolioResponse>>();

            A.CallTo(() => fPortfolioService.GetAllPortfolios()).Returns(Task.FromResult(new ApiResponse<List<PortfolioResponse>>
            {
                 Data = expectedResult,
                 IsSuccessful = true,
                 Message = "OK",
                 StatusCode = 200
            }));

            var controller = new ExploreController(fPortfolioService);

            //Act
            var result = await controller.GetAllPortfolio();

            //Assertions
            result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
            var resultObject = result as OkObjectResult;
            resultObject?.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Explore_SearchPortfolio_ReturnOk()
        {
            //Arrange
            var fPortfolioService = A.Fake<IPortfolioService>();
            var expectedResult = A.Fake<List<PortfolioResponse>>();
            var expectedAPIResult = new ApiResponse<List<PortfolioResponse>>()
            {
                Data = expectedResult,
                IsSuccessful = true,
                Message = "OK",
                StatusCode = 200
            };
            var searchTerm = "example";

            A.CallTo(() => fPortfolioService.GetPortfoliosBySearchTerm(searchTerm)).Returns(Task.FromResult(expectedAPIResult));

            var controller = new ExploreController(fPortfolioService);

            //Act
            var result = await controller.GetAllPortfolioBySearchTerm(searchTerm);

            //Assert
            result.Should().NotBeNull().And.BeOfType<OkObjectResult>();

            var resultObject = result as OkObjectResult;
            resultObject?.Value.Should().BeEquivalentTo(expectedAPIResult);
            resultObject?.StatusCode.Should().Be(200);   
        }

        [Theory]
        [InlineData("Jr")]
        public async void Explore_SearchPortfolioByRole_ReturnOk(string searchTerm)
        {
            //Arrange
            var fPortfolioService = A.Fake<IPortfolioService>();
            var fPortfolios = A.Fake<List<PortfolioResponse>>();

            A.CallTo(() => fPortfolioService.GetPortfoliosBySearchTerm(searchTerm)).Returns(Task.FromResult(new ApiResponse<List<PortfolioResponse>>
            {
                Data = fPortfolios,
                IsSuccessful = true,
                Message = "OK",
                StatusCode = 200
            }));

            var controller = new ExploreController(fPortfolioService);

            //Act
            var result = await controller.GetPortfoliosBySearchTerm(searchTerm);

            //Assertions
            result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
        }
    }
}
