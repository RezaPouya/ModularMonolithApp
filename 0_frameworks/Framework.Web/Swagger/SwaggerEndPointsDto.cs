namespace gFramework.Web.Swagger
{
    public class SwaggerEndPointsDto
    {
        public SwaggerEndPointsDto(string apiSpec, string swaggerEndPointTitle)
        {
            this.apiSpec = apiSpec;
            this.swaggerEndPointTitle = swaggerEndPointTitle;
        }

        public string apiSpec { get; set; }
        public string swaggerEndPointTitle { get; set; }
    }
}