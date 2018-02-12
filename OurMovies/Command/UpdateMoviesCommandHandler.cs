//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using MediatR;
using Movies.Backend.Core.UseCases.General;
using OurMovies.Service;
using OurMovies.ViewModel;

namespace OurMovies.Command
{
    public class UpdateMoviesCommandHandler : CommandHandlerBase, IRequestHandler<UpdateMoviesCommand, MoviesViewModel>
    {
        public MoviesViewModel Handle(UpdateMoviesCommand message)

        {
            try
            {
                string validateModel = message == null ? "Command model is null, bad request" : message.ValidateModel();
                if (string.IsNullOrEmpty(validateModel))
                {
                    var commandService = new ServiceCommand();

                    var movies = commandService.UpdateMovies(message.Id, message.Title, message.RunningTime, message.IsDeleted);

                    commandService.SaveChanges();
                    return new MoviesViewModel
                    {
                        Id = movies.Id,
                        Title = movies.Title,
                        ReleaseDate = (System.DateTime)movies.ReleaseDate,
                        IsDeleted = (bool)movies.IsDeleted,
                        RunningTime = (int)movies.RunningTime,


                    };
                }
                throw new System.Exception(validateModel);
            }
            catch (System.Exception exc)
            {

                // var log = new ExceptionLog().Log(exc, message);

                throw exc;
            }
        }

        public MoviesViewModel Handler(UpdateMoviesCommand message)
        {
            throw new System.NotImplementedException();
        }
    }

}

