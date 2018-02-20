using System.Collections.Generic;
using System.Linq;
using MediatR;
using OurMovies.Query;
using OurMovies.ViewModel;
using OurMovies.Service;
using Movies.Backend.Core.Common;
using Movies.Backend.Core.UseCases.General;

namespace Dayspring.Feature.Testimony.Query
{

    public class ListMoviesQueryHandler : QueryHandlerBase, IRequestHandler<ListMoviesQuery, List<MoviesViewModel>>
    {

        public List<MoviesViewModel> Handle(ListMoviesQuery message)
        {
            try
            {
                string validateModel = message == null ? "Command model is null, bad request" : message.ValidateModel();
                if (string.IsNullOrEmpty(validateModel))
                {
                    var ServiceQuery = new ServiceQuery();
                    IEnumerable<Movies.Backend.Core.UseCases.Data.OurMovie> movies = ServiceQuery.ListMovies();

                    return movies.Select(t => new MoviesViewModel
                    {
                        Id = t.Id,
                        Title = t.Title,
                        ReleaseDate = t.ReleaseDate,
                        RunningTime = (int)t.RunningTime,
                        IsDeleted = (bool)t.IsDeleted,
                        Discription = t.Discription,
                        Rating = t.Rating,
                        BookingId = t.BookingId

                    }).ToList();
                }
                throw new System.Exception(validateModel);
            }
            catch (System.Exception exc)
            {

                var log = new ExceptionLog().Log(exc, message);

                throw exc;
            }
        }
    }
}


