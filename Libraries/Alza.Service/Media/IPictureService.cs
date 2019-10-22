namespace Alza.Services.Media
{
    /// <summary>
    /// Picture interface interface
    /// </summary>
    public partial interface IPictureService
    {
        /// <summary>
        /// Return picture Uri
        /// </summary>
        /// <param name="pictureId"></param>
        /// <returns></returns>
        string GetPictureUri(int pictureId);
    }
}
