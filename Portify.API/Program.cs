using Portify.API;
using Portify.API.extensions;
using Portify.Persistence.extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration);

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
