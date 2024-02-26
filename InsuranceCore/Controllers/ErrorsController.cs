using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using InsuranceCore.Models.Exceptions;
using InsuranceCore.Responses;

namespace InsuranceCore.Controllers
{
    /// <summary>
    /// Errors controllers used as middleware to catch exceptions and manage behaviors.
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        /// <summary>
        /// Define HttpStatusCode and error type depending of exception raised.
        /// </summary>
        /// <returns></returns>
        [Route("error")]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(InsuranceErrorResponse), StatusCodes.Status400BadRequest)]
        public InsuranceErrorResponse Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error;
            var code = HttpStatusCode.InternalServerError;

            switch (exception)
            {
                case ResourceNotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
                case InvalidRequestException:
                case PermissionManagementException:
                case RoleManagementException:
                case UserManagementException:
                    code = HttpStatusCode.Conflict;
                    break;
                case ArgumentNullException:
                case ArgumentException:
                case ValidationException:
                    code = HttpStatusCode.BadRequest;
                    break;
            }

            Response.StatusCode = (int)code;
            return new InsuranceErrorResponse(exception.GetType().Name, exception.Message);
        }
    }
}
