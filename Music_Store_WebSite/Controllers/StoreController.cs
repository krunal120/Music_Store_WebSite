using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Music_Store_WebSite.Models;

namespace Music_Store_WebSite.Controllers
{
    public class StoreController : Controller
    {
        MvcDBMusicEntities1 storeDB = new MvcDBMusicEntities1();
        //
        // GET: /Store/
        public ActionResult Index()
        {
            var genres = storeDB.Genres.ToList();
            return View(genres);
        }
        //
        // GET: /Store/Details
        
        public ActionResult Details(int id)
        {
            var album = storeDB.Albums.Find(id);

            return View(album); 
        }
        //
        // GET: /Store/Browse
        public ActionResult Browse(string genre)
        {
            var genreModel = storeDB.Genres.Include("Albums").Single(g => g.Name == genre);
            return View(genreModel);
        }
        //
        // GET: /Store/GenreMenu
        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            var genres = storeDB.Genres.ToList();
            return PartialView(genres);
        }
    }
}