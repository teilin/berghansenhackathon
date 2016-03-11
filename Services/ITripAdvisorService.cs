using System.Threading.Tasks;

namespace  BergHansenHackathon.Services
{
    public interface ITripAdvisorService
    {
        Task<TALocationList> GetLocation(string id);
    }
}