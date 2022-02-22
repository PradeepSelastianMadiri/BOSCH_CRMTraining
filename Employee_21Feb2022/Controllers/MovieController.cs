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
        List<MovieModel> lstMovieModel = null;
        public MovieController()
        {
            lstMovieModel = new List<MovieModel>()
            {
                new MovieModel{ ID= 1, Title="RRR", Genre="Action", ReleaseDate="20 Jan 2022", Rating=5.0M, Price=1000},
                new MovieModel{ ID= 2, Title="KGF", Genre="Action", ReleaseDate="21 Jan 2022", Rating=5.0M, Price=2000},
                new MovieModel{ ID= 3, Title="Bahubali-2", Genre="Action", ReleaseDate="26 Jan 2022", Rating=5.0M, Price=3000},
                new MovieModel{ ID= 4, Title="Anubavinchu Raja", Genre="Comedy", ReleaseDate="30 Jan 2022", Rating=5.0M, Price=800}
            };
        }

        // GET: Movie
        public ActionResult GetMoviewDetails(List<MovieModel> lstMovieModel1)
        {
            //MovieModel mvMd = new MovieModel();
            //mvMd.Title = "RRR";
            //mvMd.ReleaseDate = "21 Dec 2021";
            //mvMd.Rating = 4.5M;
            //mvMd.Genre = "Action";
            //mvMd.Price = 5000000;
            if (lstMovieModel1 == null)
            {
                lstMovieModel1 = lstMovieModel;
            }

            return View(lstMovieModel1);
        }

        [HttpGet]
        public ActionResult ModifyMovie(int ID)
        {
            MovieModel mv = null;
            var movieFound = lstMovieModel.Where(x => x.ID == ID).FirstOrDefault();
            if (movieFound != null)
            {
                mv = movieFound;
            }

            return View(mv);
        }

        [HttpPost]
        public ActionResult ModifyMovie(MovieModel mv)
        {
            var movieFound = lstMovieModel.Where(x => x.ID == mv.ID).FirstOrDefault();
            if (movieFound != null)
            {
                movieFound.Title = mv.Title;
                movieFound.Genre = mv.Genre;
                movieFound.ReleaseDate = mv.ReleaseDate;
                movieFound.Rating = mv.Rating;
                movieFound.Price = mv.Price;
            }

            return View("GetMoviewDetails", lstMovieModel);
            //return RedirectToAction("MovieDetail", mv);
        }

        public ActionResult MovieDetail(MovieModel mv)
        {
            return View(mv);
        }

    }
}