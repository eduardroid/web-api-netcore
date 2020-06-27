using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace dev.eduardroid.services.Controller
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Welcome again eduardroid, Hello thereee ??? YES");
        }
    }
}
