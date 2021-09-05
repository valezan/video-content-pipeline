using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace VideoContentPipeline
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _prodivder;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _prodivder = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _prodivder.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }

        private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo
            {
                Title = "Video Content Pipeline",
                Version = description.ApiVersion.ToString(),
                Description = @"<p>Centralized web API that retuns videos metadata</p>",
            };
            if (description.IsDeprecated)
            {
                info.Description += @"<p><strong>THIS VERSION IS DEPRECATED</strong></p>";
            }
            return info;
        }
    }
}
