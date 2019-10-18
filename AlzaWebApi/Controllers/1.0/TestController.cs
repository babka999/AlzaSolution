using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AlzaWebApi.Controllers._1._0
{
    /// <summary>
    /// Test
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class TestController : Controller
    {
        /// <summary>
        /// Lala
        /// </summary>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<string>), 200)]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}