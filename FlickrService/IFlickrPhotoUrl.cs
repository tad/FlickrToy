using System.Xml.Linq;

namespace FlickrService
{
    public interface IFlickrPhotoUrl
    {
        string GetFlickrPhotoUrl();
        IFlickrPhotoUrl SetElementAndReturnSelf(XElement element);
    }
}