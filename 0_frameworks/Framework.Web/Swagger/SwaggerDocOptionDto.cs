using Microsoft.OpenApi.Models;

namespace gFramework.Web.Swagger
{
    public class SwaggerDocOptionDto
    {
        public SwaggerDocOptionDto(string name, OpenApiInfo info)
        {
            Name = name;
            Info = info;
        }

        public string Name { get; set; }
        public OpenApiInfo Info { get; set; }
    }
}