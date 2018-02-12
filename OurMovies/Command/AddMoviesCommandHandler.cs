
using MediatR;
using Movies.Backend.Core.UseCases.General;
using OurMovies.Service;
using OurMovies.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace OurMovies.Command
{
    public class AddMoviesCommandHandler : CommandHandlerBase, IRequestHandler<AddMoviesCommand, MoviesViewModel>
    {
        public MoviesViewModel Handle(AddMoviesCommand message)
        {
            try
            {
                string validateModel = message == null ? "Command model is null, bad request" : message.ValidateModel();
                if (string.IsNullOrEmpty(validateModel))
                {
                    var commandService = new ServiceCommand();

                    var Movie = commandService.CreateMovie(message.Title, message.RunningTime, message.IsDeleted);

                    commandService.SaveChanges();
                    return new MoviesViewModel
                    {

                        Title = Movie.Title,
                        IsDeleted = (bool)Movie.IsDeleted,
                        RunningTime = (int)Movie.RunningTime

                    };
                }
                throw new System.Exception(validateModel);
            }
            catch (System.Exception exc)
            {


                throw exc;
            }


        }


    }
}

