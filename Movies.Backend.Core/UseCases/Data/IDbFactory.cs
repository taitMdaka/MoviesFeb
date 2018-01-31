using Movies.Backend.Core.UseCases.Data;
using System;

namespace Movies.Backend.Core.UseCases
{
    public interface IDbFactory :IDisposable 
    {
        MoviesDataBase Init();
    }
}