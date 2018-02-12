using Movies.Backend.Core.UseCases.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurMovies.Command
{
    public class DeleteMoviesCommand : CommandResultsBase, MediatR.IRequest<bool>
    {
        [Required]
        public int Id { get; set; }
    }
}