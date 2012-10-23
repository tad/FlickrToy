using System.Xml.Linq;

namespace FlickrService
{
    public interface IFlickrWebPageUrl
    {
        string GetFlickrWebPageUrl();
        IFlickrWebPageUrl SetElementAndReturnSelf(XElement element);
    }
}