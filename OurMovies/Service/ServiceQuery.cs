using Movies.Backend.Core.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurMovies.Service
{
   
    public class ServiceQuery : ServiceQueryBase
    {
        public Movies.Backend.Core.UseCases.Data.OurMovie  GetMoviesById(int Id)
        {
            return DbContext.OurMovie.SingleOrDefault(u => u.Id == Id);
        }

        public IQueryable<Movies.Backend.Core.UseCases.Data.OurMovie> ListMovies()
        {
            return DbContext.OurMovie.Include("File").AsQueryable();
        }

    }
}





