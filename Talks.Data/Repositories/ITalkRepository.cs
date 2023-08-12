using Talks.Domain;

namespace Talks.Data.Repositories
{
    public interface ITalkRepository
    {
        List<Talk> GetTalksAsync();
    }
}
