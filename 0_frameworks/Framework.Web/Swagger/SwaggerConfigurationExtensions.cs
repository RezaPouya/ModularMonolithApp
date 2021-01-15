namespace gFramework.Web.Swagger
{
    public static class SwaggerConfigurationExtensions
    {
        //public static void AddSwagger(this IServiceCollection services, string xmlFileName, IEnumerable<SwaggerDocOptionDto> swaggerDocOptionDto)
        //{
        //    services.AddSwaggerGenNewtonsoftSupport();
        //    services.AddSwaggerGen(setupAction =>
        //    {
        //        foreach (var item in swaggerDocOptionDto)
        //            setupAction.SwaggerDoc(item.Name, new OpenApiInfo { Title = item.Info.Title, Version = item.Info.Version, Description = item.Info.Description });

        //        var xmlDocPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
        //        setupAction.IncludeXmlComments(xmlDocPath, true);

        //        // --- removing version parameter
        //        // with current code if remove version parameter, endpoint grouping will fail
        //        setupAction.OperationFilter<RemoveVersionParameters>();
        //        setupAction.DocumentFilter<SetVersionInPaths>();
        //        setupAction.DocInclusionPredicate((docName, apiDesc) =>
        //        {
        //            if (!apiDesc.TryGetMethodInfo(out MethodInfo methodInfo)) return false;

        //            var versions = methodInfo.DeclaringType
        //                .GetCustomAttributes<ApiVersionAttribute>(true)
        //                .SelectMany(attr => attr.Versions);

        //            var docMajorVersion = docName.Substring(docName.Length - 2);
        //            return versions.Any(v => $"v{v.MajorVersion}" == docMajorVersion);
        //        });
        //    });
        //}

        //public static void UseCustomSwagger(this IApplicationBuilder app, string swaggerPrefix, IEnumerable<SwaggerEndPointsDto> swaggerEndPointsDtos)
        //{
        //    app.UseSwagger();
        //    app.UseSwaggerUI(setupAction =>
        //    {
        //        foreach (var item in swaggerEndPointsDtos)
        //            setupAction.SwaggerEndpoint($"/swagger/{item.apiSpec}/swagger.json", item.swaggerEndPointTitle);

        //        setupAction.RoutePrefix = swaggerPrefix;
        //        setupAction.DefaultModelExpandDepth(2);
        //        setupAction.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Model);
        //        setupAction.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
        //        setupAction.EnableDeepLinking();
        //        setupAction.DisplayOperationId();
        //    });
        //}
    }
}