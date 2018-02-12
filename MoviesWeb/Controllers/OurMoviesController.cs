using Autofac;
using MediatR;
using Movies.Backend.Core.Infrastructure;
using OurMovies.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoviesWeb.Controllers
{
    public class OurMoviesController : Controller
    {
       
        private static IMediator _mediator;

        public OurMoviesController()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(typeof(ListMoviesQuery).Assembly).AsImplementedInterfaces();
            _mediator = BootstrapMediatr.BuildMediator(builder);
        }

        public ActionResult Index()
        {
            return View(_mediator.Send(new ListMoviesQuery()).Result);

        }


        //public ActionResult TestimoniesHome()
        //{
        //    return PartialView(_mediator.Send(new GetTestimoniesQuery()).Result.OrderByDescending(d => d.CreatedDate).Where(d => d.Show == true).Take(3));

        //}
        //public ActionResult Testimonydetails()
        //{

        //    return View();
        //}
        //[HttpGet]
        //public ActionResult Testimonydetails(int id)

        //{

        //    var GetTestimonyByID = new GetTestimonyByIDQuery
        //    {
        //        Id = id
        //    };
        //    return View(_mediator.Send(GetTestimonyByID).Result);
        //}




    }
}



   
