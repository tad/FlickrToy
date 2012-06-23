using System;
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

        public List<FlickrPhoto> GetRecentPhotos()
        {
            var address = @" http://api.flickr.com/services/rest/?method=flickr.photos.getRecent&api_key=b79df6b678836fd497f972e39b178b85&format=rest";

            var photoList = new List<FlickrPhoto>();

            var doc = new XDocument();

            var client = new HttpClient();          

            var asyncTask = client.GetAsync(address).ContinueWith(
                (requestTask) =>
                {
                    var response = requestTask.Result;
                    response.EnsureSuccessStatusCode();

                    var responseTask = response.Content.ReadAsStringAsync().ContinueWith(
                        (readTask) =>
                        {
                            doc = XDocument.Parse(readTask.Result);

                            foreach (var element in doc.Descendants("photo"))
                            {
                                var photo = new FlickrPhoto
                                {
                                    ImageUrl = GetFlickrUrl(element),
                                    WebPageUrl = GetFlickrWebPageUrl(element)
                                };

                                photoList.Add(photo);
                            }
                        });
                    Task.WaitAll(responseTask);
                });

            Task.WaitAll(asyncTask);

            return photoList;
        }

        protected  string GetFlickrUrl(XElement element)
        {
            var farm = element.Attribute("farm").Value;
            var server = element.Attribute("server").Value;
            var id = element.Attribute("id").Value;
            var secret = element.Attribute("secret").Value;

            if (null == farm || null == server || null == id || null == secret)
            {
                return "";
            }

            var url = @"http://farm" + farm + @".staticflickr.com/"
                + server + @"/" + id + @"_" + secret + @"_m.jpg";

            return url;
        }

        protected string GetFlickrWebPageUrl(XElement element)
        {
            var userId = element.Attribute("owner").Value;
            var id = element.Attribute("id").Value;

            if (null == userId || null == id)
            {
                return "";
            }

            var url = @"http://www.flickr.com/photos/" + userId + @"/" + id;

            return url;
        }
    }
}
