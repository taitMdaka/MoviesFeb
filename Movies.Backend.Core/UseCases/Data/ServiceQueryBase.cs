using Movies.Backend.Core.UseCases.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Backend.Core.UseCases
{
    public class ServiceQueryBase : Disposable, IDbFactory
    {
            protected MoviesDataBase DbContext;
        
            public MoviesDataBase Init()
            {
                return DbContext ?? (DbContext = new MoviesDataBase());
            }

            public ServiceQueryBase()
            {
                DbContext = DbContext ?? (DbContext = new MoviesDataBase());
            }

            protected override void DisposeCore()
            {
                if (DbContext != null)
                    DbContext.Dispose();
            }
        }
    }
