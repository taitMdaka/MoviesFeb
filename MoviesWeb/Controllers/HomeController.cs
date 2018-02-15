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
    public class HomeController : Controller
    {
        private static IMediator _mediator;

        public HomeController()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(typeof(ListMoviesQuery).Assembly).AsImplementedInterfaces();
            _mediator = BootstrapMediatr.BuildMediator(builder);
        }


        public ActionResult Index()
        {
            return View(_mediator.Send(new ListMoviesQuery()).Result);
        }

        //public ActionResult MovieById()
        //{
        //    return View(_mediator.Send(new ListMoviesQuery()).Result);
        //}







        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}





//namespace Dayspring.Web.Controllers
//{
//    public class TestimonyController : Controller
//    {
//        private static IMediator _mediator;

//        public TestimonyController()
//        {
//            ContainerBuilder builder = new ContainerBuilder();
//            builder.RegisterAssemblyTypes(typeof(GetTestimoniesQuery).Assembly).AsImplementedInterfaces();
//            _mediator = BootstrapMediatr.BuildMediator(builder);
//        }
//        [Authorize]
//        public ActionResult Index()
//        {
//            return View(_mediator.Send(new GetTestimoniesQuery()).Result);

//        }
//        [Authorize]
//        public ActionResult TestimoniesHome()
//        {
//            return PartialView(_mediator.Send(new GetTestimoniesQuery()).Result.OrderByDescending(d => d.CreatedDate).Where(d => d.Show == true).Take(3));

//        }
//        [Authorize]
//        public ActionResult Testimonydetails()
//        {

//            return View();
//        }
//        [Authorize]
//        [HttpGet]
//        public ActionResult Testimonydetails(int id)

//        {

//            var GetTestimonyByID = new GetTestimonyByIDQuery
//            {
//                Id = id
//            };
//            return View(_mediator.Send(GetTestimonyByID).Result);
//        }
//    }
//}


