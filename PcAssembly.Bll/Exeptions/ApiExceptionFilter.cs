using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PcAssembly.Bll.Exeptions
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if(context.Exception is ApiException apiException)
            {
                context.Result = new ObjectResult(new ServiceResponse<object>
                {
                    Data = null,
                    Success = false,
                    Message = apiException.Message
                })
                {
                    StatusCode = (int)apiException.Code
                };
            }
        }
    }
}
