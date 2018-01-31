using Movies.Backend.Core.UseCases.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Backend.Core.UseCases
{
   public class DbFactory : Disposable, IDbFactory
    {
        MoviesDataBase  _dbContext;

        public MoviesDataBase Init()
        {
            return _dbContext ?? (_dbContext = new MoviesDataBase());
        }

        protected override void DisposeCore()
        {
            if (_dbContext != null)
                _dbContext.Dispose();
        }
    }
}
