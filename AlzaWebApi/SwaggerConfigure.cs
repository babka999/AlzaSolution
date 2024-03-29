﻿using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace AlzaWebApi
{
    /// <summary>
    /// Configures the Swagger generation options.
    /// </summary>
    /// <remarks>This allows API versioning to define a Swagger document per API version after the
    /// <see cref="IApiVersionDescriptionProvider"/> service has been resolved from the service container.</remarks>
    public class SwaggerConfigure : IConfigureOptions<SwaggerGenOptions>
    {
        #region Fields

        private readonly IApiVersionDescriptionProvider _provider;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="SwaggerConfigure"/> class.
        /// </summary>
        /// <param name="provider">The <see cref="IApiVersionDescriptionProvider">provider</see> used to generate Swagger documents.</param>
        public SwaggerConfigure(IApiVersionDescriptionProvider provider) 
        {
            _provider = provider;
        }

        #endregion

        #region Public methods

        /// <inheritdoc />
        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description.ApiVersion.ToString()));
        }

        #endregion

        #region Private methods

        private Info CreateInfoForApiVersion(string version) 
            => new Info()
            {
                Title = "Alza API",
                Version = version,
                Description = ApiVersions.ContainsKey(version) ? ApiVersions[version] : ""
            };

        #endregion

        #region ApiVersions description

        private Dictionary<string, string> ApiVersions
            => new Dictionary<string, string>
            {
                { "1.0", "Api v1. All methods are only synchronous." },
                { "2.0", "Api v2. All methods are asynchronous." }
            };

        #endregion
    }
}
