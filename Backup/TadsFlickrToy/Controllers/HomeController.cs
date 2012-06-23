using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlickrService;

namespace TadsFlickrToy.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        delegate List<FlickrPhoto> AsyncMethodCaller();

        public ActionResult Index()
        {
            var client = new FlickrService.FlickrService();

            AsyncMethodCaller caller = new AsyncMethodCaller(client.GetRecentPhotos);

            var result = caller.BeginInvoke(null, null);

            var photos = caller.EndInvoke(result);

            ViewData["flickrphotos"] = photos;

            List<string> urls = new List<string>();
            foreach (var photo in photos)
            {
                urls.Add(photo.ImageUrl);
            }

            ViewData["photos"] = urls;

            return View();
        }

    }
}
