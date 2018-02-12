using Autofac;
using MediatR;
using Movies.Backend.Core.Infrastructure;
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
    }
}


//{
//    [Authorize]
//    public class AdminWebController : ApiController
//    {
//        private static IMediator _mediator;

//        public AdminWebController()
//        {
//            ContainerBuilder builder = new ContainerBuilder();
//            builder.RegisterAssemblyTypes(typeof(GetTestimoniesQuery).Assembly).AsImplementedInterfaces();
//            builder.RegisterAssemblyTypes(typeof(UploadFileByByteCommand).Assembly).AsImplementedInterfaces();
//            _mediator = BootstrapMediatr.BuildMediator(builder);
//        }

//        public List<TestimonyViewModel> GetAllTestimonies()
//        {
//            var getTestimoniesQuery = new GetTestimoniesQuery
//            {
//                WithHiden = true
//            };

//            return _mediator.Send(getTestimoniesQuery).Result;
//        }

//        [HttpPost]
//        public HttpResponseMessage AddTestimonies(TestimonyModel command)
//        {

//            try
//            {

//                var buffer = Convert.FromBase64String(command.FileData.Substring(command.FileData.IndexOf(',') + 1));

//                var UploadCommand = new UploadFileByByteCommand
//                {
//                    Name = command.FileName,
//                    fileByte = ResizeImage.Resizeimage(Convert.ToInt32(Enums.EventsPixels.Width), Convert.ToInt32(Enums.EventsPixels.Height), buffer),
//                    BlobContainer = System.Configuration.ConfigurationManager.AppSettings["testimonyBlob"],
//                    // fileByte = buffer,

//                };

//                var Upload = _mediator.Send(UploadCommand).Result;

//                var addTestimony = new AddTestimonyCommand
//                {
//                    Name = command.Name,
//                    Data = command.Data,
//                    Show = command.Show,
//                    FileID = Upload.FileID,
//                };
//                return Request.CreateResponse(HttpStatusCode.OK, _mediator.Send(addTestimony).Result);
//            }
//            catch (Exception exc)
//            {

//                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, exc.Message);
//            }
//        }

//        [HttpPut, HttpPost]
//        public TestimonyViewModel UpdateTestimonies(UpdateTestimonyCommand command)
//        {
//            return _mediator.Send(command).Result;
//        }

//        [HttpPost]
//        public bool RemoveTestimony(int id)
//        {
//            var delete = new RemoveTestimonyCommand
//            {
//                TestimonyId = id
//            };
//            return _mediator.Send(delete).Result;

//        }
//    }
//}
