using MediatR;
using Movies.Backend.Core.UseCases.General;
using OurMovies.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurMovies.Command
{
   public  class UpdateMoviesCommand : CommandResultsBase, IRequest<MoviesViewModel>
    {
        [Required]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int RunningTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}

