using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Backend.Core.UseCases.General
{
  public  class CommandResultsBase
     
    {
        public CommandResultsBase()
        {

        }
        public string ValidateModel()
        {
            var context = new ValidationContext(this, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(this, context, results, true);
            if (!isValid)
                return "Model is not valid because " + string.Join(", ", results.Select(s => s.ErrorMessage));
            else
                return string.Empty;
        }
    }
}
