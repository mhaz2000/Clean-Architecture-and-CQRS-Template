using Microsoft.AspNetCore.Mvc;

namespace CleanArchAndCQRS.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected ActionResult<TResult> OkOrNotFound<TResult>(TResult result)
            => result is null ? NotFound() : Ok(result);
    }
}
