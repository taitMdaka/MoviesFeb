using Movies.Backend.Core.UseCases.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Backend.Core.UseCases

{
    public class ServiceCommandBase : Disposable, IDbFactory
    {
        protected MoviesDataBase DbContext;

        public MoviesDataBase Init()
        {
            return DbContext ?? (DbContext = new MoviesDataBase());
        }

        public ServiceCommandBase()
        {
            DbContext = DbContext ?? (DbContext = new MoviesDataBase());
        }

        protected override void DisposeCore()
        {
            if (DbContext != null)
                DbContext.Dispose();
        }

        public int SaveChanges()
        {
            return DbContext.SaveChanges();
        }
    }
}


