using System;
using System.Xml.Linq;

namespace FlickrService
{
    public class FlickrPhotoUrl : IFlickrPhotoUrl
    {
        private string _farm;
        private string _server;
        private string _id;
        private string _secret;
        private XElement _element;

        public FlickrPhotoUrl()
        {
        }
        
        public FlickrPhotoUrl(XElement element)
        {
            _element = element;
            Initialize();         
        }

        // Return self for chaining
        public IFlickrPhotoUrl SetElementAndReturnSelf(XElement element)
        {
            _element = element;
            Initialize();
            return this;
        }

        private void Initialize()
        {
            CheckElementForNulls();
            _farm = _element.Attribute("farm").Value;
            _server = _element.Attribute("server").Value;
            _id = _element.Attribute("id").Value;
            _secret = _element.Attribute("secret").Value;  
        }

        private void CheckElementForNulls()
        {
            ValidateElement();
            ValidateAttribute("farm");
            ValidateAttribute("server");
            ValidateAttribute("id");
            ValidateAttribute("secret");
        }

        private void ValidateElement()
        {
            if (_element == null)
                throw new Exception("XElement can not be null.");
        }

        private void ValidateAttribute(string attributeName)
        {
            if (_element.Attribute(attributeName) == null)
                throw new Exception(string.Format("{0} element can not be null.", attributeName));
        }

        public string GetFlickrPhotoUrl()
        {
            if (AnyFlickrPhotoUrlPropertiesAreNull())
                return "";

            return BuildFlickrUrlAddress();
        }

        private string BuildFlickrUrlAddress()
        {
            return @"http://farm" + _farm + @".staticflickr.com/"
                   + _server + @"/" + _id + @"_" + _secret + @"_m.jpg";
        }

        private bool AnyFlickrPhotoUrlPropertiesAreNull()
        {
            if (null == _farm || null == _server || null == _id || null == _secret)
                return true;
            
            return false;
        }
    }
}