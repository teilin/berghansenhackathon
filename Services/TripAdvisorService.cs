using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.OptionsModel;
using Microsoft.Extensions.WebEncoders;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.OptionsModel;
using BergHansenHackathon.Models;

namespace BergHansenHackathon.Services
{
    public class TripAdvisorService : ITripAdvisorService
    {
        public const string CacheKey = nameof(TripAdvisorService);
        
        private readonly IHostingEnvironment _env;
        private readonly AppSettings _appSettings;
        private readonly IMemoryCache _cache;
        
        public TripAdvisorService(
            IHostingEnvironment env,
            IOptions<AppSettings> appSettings,
            IMemoryCache memoryCache
        )
        {
            _env = env;
            _appSettings = appSettings.Value;
            _cache = memoryCache;
        }

        public async Task<TALocationList> GetLocation(string id)
        {
            if(string.IsNullOrEmpty(_appSettings.TripAdvisorAPIKey))
            {
                return new TALocationList { Locations = DesignData.Locations };
            }
                
            var result = new TALocationList();
            
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_appSettings.TripAdvisorBaseUrl);
                
                var response = await client.GetAsync("/location/{id}?key={_appSettings.TripAdvisorAPIKey}");
                
                if(response.IsSuccessStatusCode)
                {
                    var strResponse = await response.Content.ReadAsStringAsync();
                    var obj = (IList<TALocation>)JsonConvert.DeserializeObject<IList<TALocation>>(strResponse);
                    result.Locations = obj;
                }
            }
            return result;
        }
        
        private static class DesignData
        {
            public static readonly IList<TALocation> Locations = new List<TALocation>
            {
                
            };
        }
    }
}