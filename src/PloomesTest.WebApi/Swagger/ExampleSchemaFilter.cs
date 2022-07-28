using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

using PloomesTest.Core.Dtos;
using PloomesTest.Core.Entities;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PloomesTest.WebApi.Swagger
{
    public class ExampleSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(CreateClientDto) || context.Type == typeof(UpdateClientDto))
            {
                schema.Example = new OpenApiObject
                {
                    ["federalDocument"] = new OpenApiString("12345678000190"),
                    ["name"] = new OpenApiString("Ploomes"),
                    ["email"] = new OpenApiString("example@ploomes.com"),
                    ["phone"] = new OpenApiString("11912234556"),
                    ["address"] = new OpenApiString("Rua Ferreira de Araujo, Pinheiros, 79"),
                    ["city"] = new OpenApiString("São Paulo"),
                    ["state"] = new OpenApiString("SP"),
                    ["zipCode"] = new OpenApiString("05428000"),
                    ["country"] = new OpenApiString("Brasil")
                };
            }

            if (context.Type == typeof(Client))
            {
                schema.Example = new OpenApiObject
                {
                    ["id"] = new OpenApiString(Guid.NewGuid().ToString()),
                    ["type"] = new OpenApiInteger(1),
                    ["typeName"] = new OpenApiString("Company"),
                    ["federalDocument"] = new OpenApiString("12345678000190"),
                    ["name"] = new OpenApiString("Ploomes"),
                    ["email"] = new OpenApiString("example@ploomes.com"),
                    ["phone"] = new OpenApiString("11912234556"),
                    ["address"] = new OpenApiString("Rua Ferreira de Araujo, Pinheiros, 79"),
                    ["city"] = new OpenApiString("São Paulo"),
                    ["state"] = new OpenApiString("SP"),
                    ["zipCode"] = new OpenApiString("05428000"),
                    ["country"] = new OpenApiString("Brasil"),

                };
            }
        }
    }
}