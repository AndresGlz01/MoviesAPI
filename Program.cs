using MoviesAPI;
using MoviesAPI.Services;
using Microsoft.EntityFrameworkCore;
using ActorsAPI.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Swashbuckle.AspNetCore.Filters;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    swaggerOpt =>
    {
        swaggerOpt.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "MoviesAPI",
            Version = "v1",
            Description = "Esta es mi API para administrar películas",
            Contact = new OpenApiContact
            {
                Name = "AndresGlz01",
                Email = "andyglz01dev@gmail.com",
                Url = new Uri("https://github.com/AndresGlz01")
            }
        });
        swaggerOpt.ExampleFilters(); 
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        swaggerOpt.IncludeXmlComments(xmlPath);

    });

builder.Services.AddDbContext<MoviesContext>(
    opt =>
    {
        opt.UseSqlServer(builder.Configuration.GetConnectionString("default"));
    });

builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
builder.Services.AddTransient<IMovieServices, MovieServices>();
builder.Services.AddTransient<IGenreService, GenreService>();
builder.Services.AddTransient<IActorServices, ActorServices>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
