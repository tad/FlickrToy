using System.Linq;
using System.Xml.Linq;
using FlickrService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlickrServiceTests
{
    public abstract class with_flickr_web_page_url : SpecificationContext
    {
        protected FlickrWebPageUrl FlickrWebPageUrl;
        protected XElement Element;
        protected string FakeXml;

        public override void Given()
        {
            FakeXml = @"<photos><photo id='8067114904' owner='60266598@N04' secret='c85d1d656c' server='8450' farm='9' title='R0010449' ispublic='1' isfriend='0' isfamily='0' /></photos>";
            var doc = XDocument.Parse(FakeXml);
            Element = doc.Descendants("photo").First();

            FlickrWebPageUrl = new FlickrWebPageUrl(Element);
        }
    }

    [TestClass]
    public class when_i_call_get_flickr_web_page_url : with_flickr_web_page_url
    {
        private string _url;

        public override void When()
        {
            _url = FlickrWebPageUrl.GetFlickrWebPageUrl();
        }

        [TestMethod]
        public void it_should_return_the_expected_url()
        {
            const string expectedUrl = @"http://www.flickr.com/photos/60266598@N04/8067114904";
            Assert.AreEqual(expectedUrl, _url);
        }
    }
}
