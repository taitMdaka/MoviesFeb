using MediatR;
using Movies.Backend.Core.UseCases.General;
using OurMovies.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurMovies.Command
{
    public class DeleteMoviesCommandHandler : CommandBase, IRequestHandler<DeleteMoviesCommand, bool>
    {
        //  public DeleteMoviesCommand()
        public bool Handle(DeleteMoviesCommand message)
        {
            try
            {
                string validateModel = message == null ? "Command model is null, bad request" : message.ValidateModel();
                if (string.IsNullOrEmpty(validateModel))
                {
                    var commandService = new ServiceCommand();

                    commandService.DeleteMovies(message.Id);

                    commandService.SaveChanges();
                    return true;
                }
                throw new System.Exception(validateModel);
            }
            catch (System.Exception exc)
            {

                //var log = new ExceptionLog().Log(exc, message);

                throw exc;
            }
        }
    }

}






   
