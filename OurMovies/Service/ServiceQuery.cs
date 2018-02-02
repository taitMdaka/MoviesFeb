using Movies.Backend.Core.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurMovies.Service
{
    public class ServiceQuery : ServiceQueryBase
    {
    {

    }
}




namespace Dayspring.Feature.Testimony.Service
{
    public class ServiceQuery : ServiceQueryBase
    {
        public Backend.Core.UseCases.Data.DB.Testimony GetTestimonyById(int testimonyId)
        {
            return DbContext.Testimonies.SingleOrDefault(u => u.Id == testimonyId);
        }

        public IQueryable<Backend.Core.UseCases.Data.DB.Testimony> GetTestimonies()
        {
            return DbContext.Testimonies.Include("File").AsQueryable();
        }

    }
}

