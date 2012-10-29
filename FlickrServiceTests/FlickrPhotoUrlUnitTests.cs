using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using FlickrService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlickrServiceTests
{
    public abstract class with_flickr_photo_url : SpecificationContext
    {
        protected FlickrPhotoUrl FlickrPhotoUrl;
        protected XElement Element;
        protected string FakeXml;

        public override void Given()
        {
            FakeXml = @"<photos><photo id='8067114904' owner='60266598@N04' secret='c85d1d656c' server='8450' farm='9' title='R0010449' ispublic='1' isfriend='0' isfamily='0' /></photos>";
            var doc = XDocument.Parse(FakeXml);
            Element = doc.Descendants("photo").First();

            FlickrPhotoUrl = new FlickrPhotoUrl(Element);

        }
    }

    [TestClass]
    public class when_i_call_get_flickr_photo_url : with_flickr_photo_url
    {
        private string _url;

        public override void When()
        {
            _url = FlickrPhotoUrl.GetFlickrPhotoUrl();
        }

        [TestMethod]
        public void it_should_return_proper_url()
        {
            const string expectedUrl = @"http://farm9.staticflickr.com/8450/8067114904_c85d1d656c_m.jpg";
            Assert.AreEqual("AAASJKGJDKER", _url);

        }
    }
}
