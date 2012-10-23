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
        public ActionResult Index()
        {
            var client = new FlickrService.FlickrService();

            var photos = client.GetRecentPhotos();

            ViewData["flickrphotos"] = photos;

            List<string> urls = new List<string>();
            foreach (var photo in photos)
                urls.Add(photo.ImageUrl);

            ViewData["photos"] = urls;

            return View();
        }

    }
}
