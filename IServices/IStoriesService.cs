using SantanderCodeTest.Models;
namespace SantanderCodeTest.IServices
{
	public interface IStoriesService
	{
		Task<IEnumerable<Story>?> GetBestStories(int count, CancellationToken cancellationToken);
	}
}
