
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
    




//namespace Dayspring.Feature.Testimony.Command
//{
//   // public class AddTestimonyCommandHandler : CommandHandlerBase, IRequestHandler<AddTestimonyCommand, TestimonyViewModel>
//    {
//        //public TestimonyViewModel Handle(AddTestimonyCommand message)
//        {
//            try
//            {
//                string validateModel = message == null ? "Command model is null, bad request" : message.ValidateModel();
//                if (string.IsNullOrEmpty(validateModel))
//                {
//                    var commandService = new ServiceCommand();

//                    var testimony = commandService.CreateTestimony(message.Name, message.Data, message.Show, message.FileID);

//                    commandService.SaveChanges();
//                    return new TestimonyViewModel
//                    {
//                        Name = testimony.Name,
//                        Id = testimony.Id,
//                        Data = testimony.Data,
//                        CreatedDate = testimony.CreatedDate,
//                        Show = testimony.Show,
//                        fileID = testimony.FileID
//                    };
//                }
//                throw new System.Exception(validateModel);
//            }
//            catch (System.Exception exc)
//            {

//                var log = new ExceptionLog().Log(exc, message);

//                throw exc;
//            }

//        }
//    }
//}

