using Movies.Backend.Core.UseCases.Data;
using MediatR;
using Movies.Backend.Core.UseCases.General;
using OurMovies.Command;
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;
//

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
    }
}