using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlickrService;
using System.Net.Http;
using System.Diagnostics;
using System.Xml;
using System.Xml.Linq;
using System.Threading;

namespace FlickrServiceTester
{
    class Program
    {
        delegate List<FlickrPhoto> AsyncMethodCaller();

        static void Main(string[] args)
        {
            var client = new FlickrService.FlickrService();

            AsyncMethodCaller caller = new AsyncMethodCaller(client.GetRecentPhotos);
            
            var result = caller.BeginInvoke(null, null);

            var photos = caller.EndInvoke(result);

            foreach (var photo in photos)
            {
                Console.WriteLine(photo.ImageUrl);
            }

            Console.ReadLine();
        }
    }
}
