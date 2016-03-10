using System.Threading.Tasks;

namespace BergHansenHackathon.Services
{
    public interface ISabreService
    {
        Task<GeoList> GetGeoAutoComplete(string query, string category, int limit = 5);
    }
}