using System.Net.Http;

namespace FlickrService
{
    public class FlickrHttpClient : IFlickrHttpClient
    {
        private readonly HttpClient _client;

        public FlickrHttpClient()
        {
            _client = new HttpClient();
        }

        public string GetRecentPhotosAsXmlFromFlickr(string address)
        {
            var responseMessage = _client.GetAsync(address).Result;
            responseMessage.EnsureSuccessStatusCode();
            return responseMessage.Content.ReadAsStringAsync().Result;
        }
    }
}
