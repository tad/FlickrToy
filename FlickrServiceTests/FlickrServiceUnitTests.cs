using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlickrService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlickrServiceTests
{
    public abstract class with_flickr_service : SpecificationContext
    {
        protected FlickrService.FlickrService flickrService;

        public override void Given()
        {
            flickrService = new FlickrService.FlickrService();
        }
    }

    [TestClass]
    public class when_i_call_get_recent_photos : with_flickr_service
    {
        private List<FlickrPhoto> _photoList; 

        public override void When()
        {
            _photoList = flickrService.GetRecentPhotos();
        }

        [TestMethod]
        public void it_should_return_the_proper_photos()
        {
            // THIS IS WHERE I STOPPED CODING.  REALIZED I SHOULD REDO THE PROJECT AS TDD
        }
    }
}
