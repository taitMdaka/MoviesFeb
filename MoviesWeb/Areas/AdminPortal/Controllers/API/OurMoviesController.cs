using Autofac;
using MediatR;
using Movies.Backend.Core.Infrastructure;
using MoviesWeb.Models;
using OurMovies.Query;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}