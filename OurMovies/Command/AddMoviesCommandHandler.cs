
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
    public class AddMoviesCommandHandler : CommandHandlerBase, IRequestHandler<GetMoviesById, MoviesViewModel>
    {
        public MoviesViewModel Handle(GetMoviesById message)
        {
            try
            {
                string validateModel = message == null ? "Command model is null, bad request" : message.ValidateModel();
                if (string.IsNullOrEmpty(validateModel))
                {
                    var ServiceCommand = new ServiceCommand();

                    var Movie = ServiceCommand.CreateMovies(message.Id,message.Title, message.RunningTime,message.ReleaseDate,message.IsDeleted);

                    ServiceCommand.SaveChanges();
                    return new MoviesViewModel
                    {

                        
                Id=message.Id,
                Title = message.Title,
                RunningTime =message.RunningTime,
                ReleaseDate = message.ReleaseDate,
                IsDeleted =message.IsDeleted
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

