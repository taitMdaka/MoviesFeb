using Autofac;
using MediatR;
using Movies.Backend.Core.Infrastructure;

using OurMovies.Command;
using OurMovies.Query;
using OurMovies.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MoviesWeb.Areas.AdminPortal.Controllers.API
{
    public class OurMoviesController : ApiController
    {
        private static IMediator _mediator;

        public OurMoviesController()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(typeof(ListMoviesQuery).Assembly).AsImplementedInterfaces();
            //builder.RegisterAssemblyTypes(typeof(UploadFileByByteCommand).Assembly).AsImplementedInterfaces();
            _mediator = BootstrapMediatr.BuildMediator(builder);
        }
        [HttpGet]
        public List<OurMovies.ViewModel.MoviesViewModel> ListMovies()
        {
            var listMoviesQuery = new ListMoviesQuery
            {
                //WithHiden = true
            };
            return _mediator.Send(listMoviesQuery).Result;
        }

        [HttpPost]
        public HttpResponseMessage AddMovie(MoviesViewModel command)
        {

            try
            {

                var AddMoviesCommand = new OurMovies.Command.GetMoviesById
                {
                    Id = command.Id,
                    Title = command.Title,
                    ReleaseDate = command.ReleaseDate,
                    RunningTime = command.RunningTime,
                    IsDeleted = command.IsDeleted

                };

                return Request.CreateResponse(HttpStatusCode.OK, _mediator.Send(AddMoviesCommand).Result);
            }
            catch (Exception e)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }

        }
        

        [HttpPut, HttpPost]
        public HttpResponseMessage UpdateMoviesCommand(MoviesViewModel command)
        {
            try
            {
                var UpdateMoviesCommand = new UpdateMoviesCommand
                {
                    Id = command.Id,
                    Title = command.Title,
                    ReleaseDate = command.ReleaseDate,
                    RunningTime = command.RunningTime,
                    IsDeleted = command.IsDeleted
                };

                return Request.CreateResponse(HttpStatusCode.OK, _mediator.Send(UpdateMoviesCommand).Result);
            }
            catch (Exception e)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [HttpPost]
        public bool RemoveEvent(int Id)
        {
            var DeleteMoviesCommand = new DeleteMoviesCommand
            {
                Id = Id
            };
            return _mediator.Send(DeleteMoviesCommand).Result;
        }

        [HttpGet]
        public MoviesViewModel GetMoviesById(int id)
        {
            var results = new OurMovies.Query.GetMoviesById
            {
                Id = id

            };
            return _mediator.Send(results).Result;

        }

    }
}






