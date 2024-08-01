using Microsoft.AspNetCore.Mvc;
using SantanderCodeTest.IServices;
namespace SantanderCodeTest.Controllers
{
	public class StoriesController : Controller
	{
		private readonly IStoriesService _storiesService;
		public StoriesController(IStoriesService storiesService)
		{
			_storiesService = storiesService;
		}

		[HttpGet]
		[Route("GetStories")]
		public async Task<IResult> GetStories([FromQuery(Name = "Count")] int Count, CancellationToken cancellationToken)
		{
			var stories = await _storiesService.GetBestStories(Count, cancellationToken).ConfigureAwait(false);
			return Results.Ok(stories);
		}
	}
}
