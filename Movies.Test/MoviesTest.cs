using MediatR;
using NUnit.Framework;
using System;

using Autofac;
using OurMovies.Command;
using Movies.Backend.Core.Infrastructure;
using System.Runtime.Remoting.Messaging;

namespace Movies.Test
{
    [TestFixture]
    public class MoviesTest
    {
        private static readonly IMediator Mediator = SetupMediatr();
        public static IMediator SetupMediatr()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(typeof(AddMoviesCommand).Assembly).AsImplementedInterfaces();
            return BootstrapMediatr.BuildMediator(builder);

        }

        [Test]
        public void AddValidMovieTest()
        {
            var AddMoviesCommand = MoviesTestHelper.GetValidMovie();
            var results = Mediator.Send(AddMoviesCommand).Result;
            Assert.AreEqual(false, results.Id > 0);
        }

        [Test]
        public void AddInValidTest()
        {
            var AddMoviesCommand = MoviesTestHelper.GetInValidMovie();
            Assert.Throws<Exception>(() => Mediator.Send(AddMoviesCommand));
        }
    }
}



//[Test]
//public void AddValidTestimonyTest()
//{
//    var addTestimonyCommand = Helper.GetValidTestimony();
//    var results = Mediator.Send(addTestimonyCommand).Result;
//    Assert.AreEqual(true, results.Id > 0);
//}

//[Test]
//public void AddInValidTestimonyTest()
//{
//    var addTestimonyCommand = Helper.GetInValidTestimony();
//    Assert.Throws<Exception>(() => Mediator.Send(addTestimonyCommand));
//}


