using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlickrService
{
    public interface IFlickrService
    {
        List<FlickrPhoto> GetRecentPhotos();
    }
}
