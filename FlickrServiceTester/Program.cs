using System;

namespace FlickrServiceTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new FlickrService.FlickrService();

            var photos = client.GetRecentPhotos();

            foreach (var photo in photos)
            {
                Console.WriteLine(photo.ImageUrl);
            }

            Console.ReadLine();
        }
    }
}
