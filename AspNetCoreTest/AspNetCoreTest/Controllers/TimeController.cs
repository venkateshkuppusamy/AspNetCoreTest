using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
    public class TimeController : ControllerBase
    {
        // GET: api/Time
        [HttpGet]
        
        public IActionResult Get()
        {
            return Ok(DateTime.Now);
        }

    }
}
