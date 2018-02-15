using OurMovies.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Test
{
    public class MoviesTestHelper
    {
        public static string GetRendomNumber()
        {
            var random = new Random();
            var randomNumber = string.Join(string.Empty, Enumerable.Range(0, 10).Select(number => random.Next(0, 9).ToString()));

            return randomNumber;
        }
        public static GetMoviesById GetValidMovie(bool IsDelete = true)
        {
            return new GetMoviesById
            {
                Title="tt",
                //IsDeleted=false,
                // ReleaseDate=DateTime.Now,
                  RunningTime =250
              
                   
                  
            };
        }
        public static GetMoviesById GetInValidMovie()
        {
            return new GetMoviesById
            {               
            };
        }

        internal static object GetValidMovie(object showFlag)
        {
            throw new NotImplementedException();
        }
    }
}




   
       