namespace FlickrService
{
    public interface IFlickrHttpClient
    {
        string GetRecentPhotosAsXmlFromFlickr(string address);
    }
}