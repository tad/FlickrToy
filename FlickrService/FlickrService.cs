using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Xml.Linq;
using System.Threading.Tasks;


namespace FlickrService
{
    public class FlickrService : IFlickrService
    {
        private const string _address = @"http://api.flickr.com/services/rest/?method=flickr.photos.getRecent&api_key=b79df6b678836fd497f972e39b178b85&format=rest";
        private readonly HttpClient _client;
        private readonly IFlickrPhotoUrl _flickrPhotoUrl;
        private readonly IFlickrWebPageUrl _flickrWebPageUrl;

<<<<<<< HEAD
        public List<FlickrPhoto> GetRecentPhotos()
        {
            var address = @" http://api.flickr.com/services/rest/?method=flickr.photos.getRecent&api_key=YOURAPIKEYHERE&format=rest";

            var photoList = new List<FlickrPhoto>();
=======
>>>>>>> Refactored to be more clean, but...

        public FlickrService(HttpClient client, IFlickrPhotoUrl flickrPhotoUrl, IFlickrWebPageUrl flickrWebPageUrl)
        {
            _client = client;
            _flickrPhotoUrl = flickrPhotoUrl;
            _flickrWebPageUrl = flickrWebPageUrl;
        }

        public FlickrService()
        {
            _client = new HttpClient();
            _flickrPhotoUrl = new FlickrPhotoUrl();
            _flickrWebPageUrl = new FlickrWebPageUrl();
        }

        public List<FlickrPhoto> GetRecentPhotos()
        {            
            var photoList = GetPhotosFromFlickr(_address);
            return photoList;
        }

        private List<FlickrPhoto> GetPhotosFromFlickr(string address)
        {
            var content = GetRecentPhotosAsXmlFromFlickr(address);
            var doc = XDocument.Parse(content);
            return doc.Descendants("photo").Select(element => new FlickrPhoto
                {
                    ImageUrl = _flickrPhotoUrl.SetElementAndReturnSelf(element).GetFlickrPhotoUrl(), 
                    WebPageUrl = _flickrWebPageUrl.SetElementAndReturnSelf(element).GetFlickrWebPageUrl()
                }).ToList();
        }

        private string GetRecentPhotosAsXmlFromFlickr(string address)
        {
            var responseMessage = _client.GetAsync(address).Result;
            responseMessage.EnsureSuccessStatusCode();
            return responseMessage.Content.ReadAsStringAsync().Result;
        }
    }
}
