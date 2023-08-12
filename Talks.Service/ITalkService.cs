using Talks.Service.Models;

namespace Talks.Service
{
    public interface ITalkService
    {
        IEnumerable<TalksDTO> GetTalksAsync();
    }
}
