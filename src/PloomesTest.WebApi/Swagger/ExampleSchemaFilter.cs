using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

using PloomesTest.Core.Dtos;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace PloomesTest.WebApi.Swagger
{
    public class ExampleSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(CreateClientDto))
            {
                schema.Example = new OpenApiObject
                {
                    ["federalDocument"] = new OpenApiString("12345678000190"),
                    ["name"] = new OpenApiString("Ploomes"),
                    ["email"] = new OpenApiString("example@domain.com"),
                    ["phone"] = new OpenApiString("11912234556"),
                    ["address"] = new OpenApiString("Rua Ferreira de Araujo, Pinheiros, 79"),
                    ["city"] = new OpenApiString("São Paulo"),
                    ["state"] = new OpenApiString("SP"),
                    ["zipCode"] = new OpenApiString("05428000"),
                    ["country"] = new OpenApiString("Brasil")
                };
            }
        }
    }
}