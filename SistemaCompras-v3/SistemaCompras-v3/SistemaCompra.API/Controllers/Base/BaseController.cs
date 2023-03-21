using Microsoft.AspNetCore.Mvc;

namespace SistemaCompra.API.Controllers.Base
{
    public class BaseController: Controller
    {
        public IActionResult GetResponse<T>( T value)
        {
            if(value == null)
                return NoContent();

            return Ok(value);
        }
    }
}
