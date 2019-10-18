using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AlzaWebApi.Controllers._2._0
{
    /// <summary>
    /// Test
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("v{version:apiVersion}/[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class TestController : Controller
    {
        /// <summary>
        /// Lala
        /// </summary>
        /// <returns></returns>
        [MapToApiVersion("2.0")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<string>), 200)]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}