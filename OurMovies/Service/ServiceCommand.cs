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
        public Movies.Backend.Core.UseCases.Data.OurMovie CreateMovies(int Id, string Title, int RunningTime, System.DateTime ReleaseDate, bool IsDeleted, string Rating, string Discription, int BookingId)
        {
            var movies = new Movies.Backend.Core.UseCases.Data.OurMovie
            {
                Id = Id,
                Title = Title,
                RunningTime = RunningTime,
                ReleaseDate = ReleaseDate,
                IsDeleted = IsDeleted,
                Rating = Rating,
                Discription = Discription,
                BookingId = BookingId


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
                throw new System.Exception("Movie not found ");
            }
        }


        public Movies.Backend.Core.UseCases.Data.OurMovie UpdateMovies(int Id, string Title, int RunningTime, System.DateTime ReleaseDate, bool IsDeleted,string Rating,string Discription, int BookingId)
        {
            var Movies = DbContext.OurMovie.SingleOrDefault(t => t.Id == Id);
            if (Movies != null)
            {

                Movies.Id = Id;
                Movies.Title = Title;
                Movies.RunningTime = RunningTime;
                Movies.IsDeleted = IsDeleted;
                Movies.Discription = Discription;
                Movies.BookingId = BookingId;
                Movies.Rating = Rating;
                Movies.ReleaseDate = ReleaseDate; 
          
            }
            else
            {
                throw new System.Exception("Testimony was not found!");
            }

            return Movies;
        }
    }
}