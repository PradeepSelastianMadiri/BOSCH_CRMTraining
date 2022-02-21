using Employee_21Feb2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee_21Feb2022.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult GetMoviewDetails()
        {
            MovieModel mvMd = new MovieModel();
            mvMd.Title = "RRR";
            mvMd.ReleaseDate = "21 Dec 2021";
            mvMd.Rating = 4.5M;
            mvMd.Genre = "Action";
            mvMd.Price = 5000000;

            return View(mvMd);
        }
    }
}