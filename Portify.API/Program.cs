using Portify.API.Mapping;
using Portify.API.Middleware;
using Portify.API.Startup;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Configure services using ServiceConfiguration
ServiceConfiguration.ConfigureServices(builder.Services, builder.Configuration, builder.Environment);

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Portify API v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();


// Use CORS before authentication/authorization
app.UseCors("AllowAll");

app.UseAuthentication();

app.UseAuthorization();

// Add global exception handling middleware
app.UseGlobalExceptionHandling();

// Register Mapster mappings
MapsterConfig.RegisterMappings();

app.MapControllers();

app.Run();
