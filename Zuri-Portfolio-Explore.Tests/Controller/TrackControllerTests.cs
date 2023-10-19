using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zuri_Portfolio_Explore.Controllers;
using Zuri_Portfolio_Explore.Domains.DTOs.Response;
using Zuri_Portfolio_Explore.Repository.Interfaces;

namespace Zuri_Portfolio_Explore.Tests.Controller
{
	public class TrackControllerTests
	{

		private readonly ITrackService _trackService;

		public TrackControllerTests()
		{
			_trackService = A.Fake<ITrackService>();
		}

		[Fact]
		public async Task Track_GetAllTracks_ReturnsOk()
		{
			var fTrackService = A.Fake<ITrackService>();
			var expectedResult = new ApiResponse<List<TrackResposne>>()
			{
				Data = new List<TrackResposne>(),
				IsSuccessful = true,
				Message = "Success",
				StatusCode = 200
			};

			A.CallTo(() => fTrackService.GetTracks()).Returns(expectedResult);

			var controller = new TrackController(fTrackService);

			var result = await controller.GetTracks();

			result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
		}
	}
}
