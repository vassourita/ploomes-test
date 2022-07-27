using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

using PloomesTest.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.InjectDependencies(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options => options.SwaggerDoc("v1", new OpenApiInfo { Title = "PloomesTest API", Version = "v1" }));
builder.Services.Configure<ApiBehaviorOptions>(
    options => options.SuppressModelStateInvalidFilter = true
);

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
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
