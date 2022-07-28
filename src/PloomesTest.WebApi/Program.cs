using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

using PloomesTest.Infrastructure;
using PloomesTest.WebApi.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.InjectDependencies(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo { Title = "PloomesTest API", Version = "v1" });
        options.SchemaFilter<ExampleSchemaFilter>();
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "PloomesTest.WebApi.xml"), true);
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "PloomesTest.Core.xml"), true);

    });
builder.Services.Configure<ApiBehaviorOptions>(
    options => options.SuppressModelStateInvalidFilter = true
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger()
        .UseSwaggerUI(
        options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = string.Empty;
        }
    );
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
