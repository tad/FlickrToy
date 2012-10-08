using System.Collections.Generic;

namespace FlickrService
{
    public interface IFlickrService
    {
        List<FlickrPhoto> GetRecentPhotos();
    }
}
