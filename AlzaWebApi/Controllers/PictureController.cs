using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AlzaWebApi.Controllers
{
    /// <summary>
    /// Picture controller
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = true)]
    public class PictureController : Controller
    {
        /// <summary>
        /// Method return picture file
        /// </summary>
        /// <returns></returns>
        [Route("picture/{id}")]
        public async Task<FileResult> Picture(int id) => File(await System.IO.File.ReadAllBytesAsync($"wwwroot\\img\\alzak.png"), "image/png", $"{id}.png");
    }
}