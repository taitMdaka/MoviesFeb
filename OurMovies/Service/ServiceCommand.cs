using Movies.Backend.Core.UseCases.Data;
using MediatR;
using Movies.Backend.Core.UseCases.General;
using OurMovies.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;

namespace OurMovies.Service
{
    public class ServiceCommand : Movies.Backend.Core.UseCases.ServiceCommandBase
    {
        public Movies.Backend.Core.UseCases.Data.OurMovie CreateMovie(string Title, int RunningTime, bool IsDeleted)
        {
            var movies = new Movies.Backend.Core.UseCases.Data.OurMovie
            {

                Title = Title,
                RunningTime = RunningTime,
                ReleaseDate = DateTime.Now,
                IsDeleted = IsDeleted

            };
            DbContext.OurMovie.Add(movies);

            return movies;

        }

        public void DeleteMovies(int Id)
        {
            var Movies = DbContext.OurMovie.SingleOrDefault(t => t.Id == Id);
            if (Movies != null)
            {
                DbContext.OurMovie.Remove(Movies);
            }
            else

            {
                throw new Exception("Movie not found ");
            }
        }


        public Movies.Backend.Core.UseCases.Data.OurMovie UpdateMovies(int Id, string Title, int RunningTime, bool IsDeleted)
        {
            var Movies = DbContext.OurMovie.SingleOrDefault(t => t.Id == Id);
            if (Movies != null)
            {


                Movies.Title = Title;
                Movies.RunningTime = RunningTime;
                Movies.IsDeleted = IsDeleted;
            }
            else
            {
                throw new Exception("Testimony was not found!");
            }

            return Movies;
        }
    }
}