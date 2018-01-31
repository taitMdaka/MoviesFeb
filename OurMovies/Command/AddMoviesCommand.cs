using MediatR;
using Movies.Backend.Core.UseCases.General;
using OurMovies.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurMovies.Command
{
    public class AddMoviesCommand : CommandResultsBase, IRequest<MoviesViewModel>
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int RunningTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
