using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace gFramework.Web.Swagger
{
    public class SetVersionInPaths : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var newList = new OpenApiPaths();

            foreach (var entry in swaggerDoc.Paths)
            {
                newList.Add(entry.Key.Replace("{version}", swaggerDoc.Info.Version), entry.Value);
            }

            swaggerDoc.Paths.Clear();
            swaggerDoc.Paths = newList;
        }
    }
}