using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurMovies.Command
{
    class UpdateMoviesCommandHandler
    {
    }
}





{
    public class UpdateTestimonyCommandHandler : CommandHandlerBase, IRequestHandler<UpdateTestimonyCommand, TestimonyViewModel>
{
    public TestimonyViewModel Handle(UpdateTestimonyCommand message)

    {
        try
        {
            string validateModel = message == null ? "Command model is null, bad request" : message.ValidateModel();
            if (string.IsNullOrEmpty(validateModel))
            {
                var commandService = new ServiceCommand();

                var testimony = commandService.UpdateTestimony(message.Id, message.Name, message.Data, message.Show);

                commandService.SaveChanges();
                return new TestimonyViewModel
                {
                    Name = testimony.Name,
                    Id = testimony.Id,
                    Data = testimony.Data,
                    CreatedDate = testimony.CreatedDate,
                    Show = testimony.Show,
                    fileID = testimony.FileID
                };
            }
            throw new System.Exception(validateModel);
        }
        catch (System.Exception exc)
        {

            var log = new ExceptionLog().Log(exc, message);

            throw exc;
        }