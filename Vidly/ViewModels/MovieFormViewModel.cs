﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> GenreTypes { get; set; }
        public Movie Movie { get; set; }

        public string Title
        {
            get
            {
                return (Movie?.Id != 0) ? "Edit Movie" : "New Movie";
            }
        }
    }
}