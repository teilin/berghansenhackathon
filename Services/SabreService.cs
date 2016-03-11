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
    public class SabreService : ISabreService
    {
        public const string CacheKey = nameof(SabreService);
        
        private readonly IHostingEnvironment _env;
        private readonly AppSettings _appSettings;
        private readonly IMemoryCache _cache;
        
        public SabreService(
            IHostingEnvironment env,
            IOptions<AppSettings> appSettings,
            IMemoryCache memoryCache
        )
        {
            _env = env;
            _appSettings = appSettings.Value;
            _cache = memoryCache;
        }
        
        public async Task<GeoList> GetGeoAutoComplete(string query, string category, int limit)
        {
            var accessToken = await SabreAuthenticate();
            
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_appSettings.SabreEnviroment);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.access_token);
                
                var response = await client.GetAsync(
                    string.Format("/v1/lists/utilities/geoservices/autocomplete?query={0}&category={1}&limit={2}",
                        query, category, limit));
                        
                if(response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    //Vurdere hva jeg skal gjøre i de tilfellene token har utløpt
                    //return await GetGeoAutoComplete(query, category, limit);
                }
                        
                var result = new GeoList();
                        
                if(response.IsSuccessStatusCode)
                {
                    var strResponse = await response.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject(strResponse) as JObject;
                    var rawResult = obj["grouped"][string.Format("category:{0}", category)]["doclist"]["docs"]
                    .Select(item => new Geo
                    {
                        name = (string)item["name"]
                    }).ToList();
                    
                    result.Geos = rawResult;
                }
                
                return result;
            }
        }
        
        private async Task<AccressToken> SabreAuthenticate()
        {
            var apisecret = Environment.GetEnvironmentVariable("SABREAPISECRET");
            var credentials = Base64Encode(string.Format("{0}:{1}", _appSettings.SabreClientID, apisecret));
            
            var result = _cache.Get<AccressToken>(CacheKey);
            
            if(result == null)
            {
            
                using(var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_appSettings.SabreEnviroment);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
                
                    var payloadData = new List<KeyValuePair<string, string>>();
                    payloadData.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
                    
                    var payload = new FormUrlEncodedContent(payloadData) as HttpContent;
                    
                    var response = await client.PostAsync("/v2/auth/token", payload);
                    
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<AccressToken>(stringResponse);
                    
                    if(response.IsSuccessStatusCode)
                    {
                        _cache.Set(CacheKey, result, new MemoryCacheEntryOptions
                        {
                            AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(result.expires_in)
                        });
                    }
                }
            }
            return result;
        }
        
        private static string Base64Encode(string encode)
        {
            var encodeByte = System.Text.Encoding.UTF8.GetBytes(encode);
            return System.Convert.ToBase64String(encodeByte);
        }
    }
        
    public class AccressToken
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
    }
}