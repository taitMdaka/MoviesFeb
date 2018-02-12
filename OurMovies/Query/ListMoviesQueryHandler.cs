//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using MediatR;
//using System.IO;
//using static System.Net.WebRequestMethods;
//using Movies.Backend.Core.UseCases.General;
//using OurMovies.Query;
//using OurMovies.ViewModel;
//using OurMovies.Service;

//namespace OurMovies.Service
//{
//    public class ListMoviesQueryHandler : QueryHandlerBase, IRequestHandler<ListMoviesQuery, List<MoviesViewModel>>
//    {
      
//        public List<MoviesViewModel> Hander(ListMoviesQuery message)
//        {
      
//            {
//                string validateModel = message == null ? "Command model is null, bad request" : message.ValidateModel();
//                if (string.IsNullOrEmpty(validateModel))
//                {
//                    var queryService = new ServiceQuery();
//                    IEnumerable<Movies.Backend.Core.UseCases.Data.OurMovie> movies = queryService.ListMovies();

//                    //if (!message.WithHiden)
//                    //{
//                    //    movies = movies.Where(t => t.Show);
//                    //}

//                    //if (message.Limit != null)
//                    //{
//                    //    movies = movies.Take(message.Limit.Value);
//                    //}
//                    return movies.Select(t => new MoviesViewModel
//                    {

//                        //Title = t.Title,
//                        //RunningTime = t.RunningTime,
//                        //IsDeleted = t.IsDeleted,
//                        //ReleaseDate = t.ReleaseDate


//                    }).ToList();


//                }
//        }   } 
//    }
//}



