using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Moviesapi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var ConnictionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>( options => options.UseSqlServer(ConnictionString ));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "My First api",
        Description = "My first api",
        TermsOfService = new Uri("http://www.google.com"),
        Contact = new OpenApiContact {
            Name = "dr ahmed mohmmmed alghawri",
            Email = "akdfjsal@gmail.com",
            Url= new Uri("http://www.google.com")
        },
        License = new OpenApiLicense
        {
            Name = "License",
            Url = new Uri("http://www.google.com")
            
        }
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Auth",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header, 
        Description = "enter your JWT in box"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
        
    });
} );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
