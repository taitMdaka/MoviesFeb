using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurMovies.ViewModel
{
    public class MoviesViewModel

    {
        public int Id { get; set; }
        public string Title { get; set; }
        public System.DateTime ReleaseDate { get; set; }
        public Nullable<int> RunningTime { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public string Rating { get; set; }
        public string Discription { get; set; }
        public Nullable<int> BookingId { get; set; }
    }
}

