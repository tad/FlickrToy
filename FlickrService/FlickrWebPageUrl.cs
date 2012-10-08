using System;
using System.Xml.Linq;

namespace FlickrService
{
    public class FlickrWebPageUrl : IFlickrWebPageUrl
    {
        private string _userId;
        private string _id;

        private XElement _element;

        public FlickrWebPageUrl()
        {
            
        }

        public FlickrWebPageUrl(XElement element)
        {
            _element = element;
            Initialize();
        }

        private void Initialize()
        {
            ThrowExceptionIfElementIsNull(_element);
            _userId = _element.Attribute("owner").Value;
            _id = _element.Attribute("id").Value;
        }

        public string GetFlickrWebPageUrl()
        {
            if (FlickrWebPageUrlPropertiesAreNull())
                return "";

            return BuildFlickrUrlAddress();
        }

        // Returns self for chaining
        public IFlickrWebPageUrl SetElementAndReturnSelf(XElement element)
        {
            _element = element;
            Initialize();
            return this;
        }

        private string BuildFlickrUrlAddress()
        {
            return @"http://www.flickr.com/photos/" + _userId + @"/" + _id;
        }

        private bool FlickrWebPageUrlPropertiesAreNull()
        {
            if (_userId == null || _id == null)            
                return true;
           
            return false;
        }

        private void ThrowExceptionIfElementIsNull(XElement element)
        {
            if (element == null)
                throw new Exception("XElement is null.");
        }
    }
}