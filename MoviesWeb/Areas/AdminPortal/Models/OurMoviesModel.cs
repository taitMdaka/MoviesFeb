﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesWeb.Areas.AdminPortal.Models
{
    public class OurMoviesModel
    
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public System.DateTime ReleaseDate { get; set; }
        public int RunningTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
