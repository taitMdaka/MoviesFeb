using Movies.Backend.Core.UseCases;
using Movies.Backend.Core.UseCases.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Backend.Core.Common
{
    public class ExceptionLog : ServiceCommandBase
    {
        public bool Log(System.Exception ex, object message)
        {
            try
            {
                Trace.TraceError(ex.ToString(), message);

                DbContext.Exceptions.Add(new UseCases.Data.Exception
                {

                    InnerException = ex.InnerException?.Message ?? string.Empty,
                    Data = ex.Data.ToString(),
                    HelpLink = ex.HelpLink,
                    HResult = ex.HResult.ToString(),
                    Source = ex.Source,
                    StackTrace = ex.StackTrace,
                    TargetSite = ex.TargetSite != null ? ex.TargetSite.Name : string.Empty,
                    Message = ex.Message
                });
                DbContext.SaveChanges();

                return true;
            }
            catch
            {
                //we cant throw error when logging errors.
                return true;
            }
        }
    }
}