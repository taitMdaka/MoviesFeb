using MediatR;
using Movies.Backend.Core.UseCases.General;
using OurMovies.Service;
using OurMovies.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurMovies.Query
{
    public class GetMoviesByIdHandler : QueryHandlerBase, IRequestHandler<GetMoviesById, MoviesViewModel>
    {
        public MoviesViewModel Handle(GetMoviesById message)
        {
            try
            {
                string validateModel = message == null ? "Command model is null, bad request" : message.ValidateModel();
                if (string.IsNullOrEmpty(validateModel))
                {
                    var queryService = new ServiceQuery();
                    var movies = queryService.GetMoviesById(message.Id);
                    return new MoviesViewModel
                    {
                        Id = message.Id,
                        IsDeleted = (bool)movies.IsDeleted,
                        ReleaseDate = movies.ReleaseDate,
                        RunningTime = (int)movies.RunningTime,
                        Title = movies.Title,

                    };
                }
                throw new System.Exception(validateModel);
            }
            catch (System.Exception)
            {
                throw;
            }




        }
    }


}