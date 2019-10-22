using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Alza.Services.Media
{
    /// <summary>
    /// Picture service
    /// </summary>
    public partial class PictureService : IPictureService
    {
        #region Consts
        private const string PICTURE_RELATIVE_PATH = "/picture/";
        #endregion

        #region Fields

        private readonly HttpContext _httpContext;

        #endregion

        #region Ctor

        public PictureService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor.HttpContext;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Return picture Uri
        /// </summary>
        /// <param name="pictureId"></param>
        /// <returns></returns>
        public string GetPictureUri(int pictureId) => $"{(_httpContext.Request.IsHttps ? "https://" : "http://")}{_httpContext.Request.Host.Value}{PICTURE_RELATIVE_PATH}{pictureId}";

        #endregion
    }
}
