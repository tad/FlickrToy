using System.Collections.Generic;
using FlickrService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FlickrServiceTests
{
    public abstract class with_flickr_service : SpecificationContext
    {
        protected FlickrService.FlickrService flickrService;
        protected Mock<IFlickrHttpClient> _flickrClient = new Mock<IFlickrHttpClient>(MockBehavior.Loose);

        public override void Given()
        {
            flickrService = new FlickrService.FlickrService(_flickrClient.Object);
        }
    }

    [TestClass]
    public class when_i_call_get_recent_photos : with_flickr_service
    {
        private List<FlickrPhoto> _photoList;
        
        public override void When()
        {
            _flickrClient.Setup(f => f.GetRecentPhotosAsXmlFromFlickr(It.IsAny<string>())).Returns(
                @"<?xml version='1.0' encoding='utf-8' ?>
                    <rsp stat='ok'>
                      <photos page='1' pages='10' perpage='100' total='1000'>   
                        <photo id='8109312203' owner='56616467@N06' secret='1bba9f139d' server='8468' farm='9' title='2012 Tyler Rose Festival Parade' ispublic='1' isfriend='0' isfamily='0' />
                        <photo id='8109312231' owner='61151278@N08' secret='6daf9f7e54' server='8186' farm='9' title='DSC_9830-2' ispublic='1' isfriend='0' isfamily='0' />
                        <photo id='8109312423' owner='10496603@N07' secret='0aa8ef567a' server='8463' farm='9' title='F5B_011_0384_CO -uld' ispublic='1' isfriend='0' isfamily='0' />
                        <photo id='8109312469' owner='12798498@N05' secret='d201366584' server='8051' farm='9' title='MCM_2262' ispublic='1' isfriend='0' isfamily='0' />    
                      </photos>
                    </rsp>"
                );
            _photoList = flickrService.GetRecentPhotos();
        }

        [TestMethod]
        public void it_should_return_the_proper_photos()
        {
            Assert.AreEqual(4, _photoList.Count);
            var photo = _photoList[0];
            var expectedPhotoUrl = @"http://farm9.staticflickr.com/8468/8109312203_1bba9f139d_m.jpg";
            var expectedFlickrUrl = @"http://www.flickr.com/photos/56616467@N06/8109312203";
            Assert.AreEqual(expectedPhotoUrl, photo.ImageUrl);
            Assert.AreEqual(expectedFlickrUrl, photo.WebPageUrl);
        }
    }
}
