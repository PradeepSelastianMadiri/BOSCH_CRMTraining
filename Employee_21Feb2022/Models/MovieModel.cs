using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee_21Feb2022.Models
{
    public class MovieModel
    {
        //title,releasing date, genre, rating, price
        public int ID { get; set; }
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Rating { get; set; }
        public decimal Price { get; set; }
    }
}