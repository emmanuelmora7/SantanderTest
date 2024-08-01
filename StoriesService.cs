using SantanderCodeTest.Models;
using SantanderCodeTest.IServices;
using RestSharp;
using Microsoft.VisualBasic;
using System.Threading;
using System.Text.Json;

namespace SantanderCodeTest.Services
{
	public class StoriesService : IStoriesService
	{
		private readonly IHttpClientFactory _httpClientF;
		public StoriesService(IHttpClientFactory httpClientFactory)
		{
			_httpClientF = httpClientFactory;
		}
		public async Task<IEnumerable<Story>> GetBestStories(int count, CancellationToken cancellationToken) 
		{
			using HttpClient httpClient = _httpClientF.CreateClient("StoriesAPI");
			httpClient.BaseAddress = new Uri("https://hacker-news.firebaseio.com/v0/");

			using HttpResponseMessage response = await httpClient.GetAsync("beststories.json")
			.ConfigureAwait(false);

			var bestSoriesIds = await JsonSerializer.DeserializeAsync<IEnumerable<int>>(
					 await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false),
					 JsonSerializerOptions.Default, cancellationToken)
					 .ConfigureAwait(false);

			Task<Story>[] topStories = bestSoriesIds.Select(id =>
			{
				return GetStoryById(id, cancellationToken);
			}).OrderByDescending(x => x.Result.score).Take(count).ToArray();

			return await Task.WhenAll(topStories);
		}

		private async Task<Story> GetStoryById(int id, CancellationToken cancellationToken)
		{
				using HttpClient httpClient = _httpClientF.CreateClient("StoriesAPI");
				httpClient.BaseAddress = new Uri("https://hacker-news.firebaseio.com/v0/");

				using HttpResponseMessage response = await httpClient.GetAsync($"item/{id}.json", cancellationToken);

				return await JsonSerializer.DeserializeAsync<Story>(
						await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false),
						JsonSerializerOptions.Default, cancellationToken).ConfigureAwait(false);
		}
	}
}
