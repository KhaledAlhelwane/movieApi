
using Microsoft.OpenApi.Models;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//configuring cors 
builder.Services.AddCors();
var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(ConnectionString));
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo {
        Version="v1",
        Title = "Api with DevCreed" ,
        Description="this is an api totrial",
        TermsOfService=new Uri("https://www.google.com"),
        Contact= new OpenApiContact { Name="khaled",Email="khaledhewalne@gamil.com",Url=new Uri("https://www.google.com") },
        License=new OpenApiLicense { Name="myLicense",Url= new Uri("https://www.google.com") }
    });
}) ;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//configuring  cors :cross origin resource sharing 
app.UseCors(options =>options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseAuthorization();

app.MapControllers();

app.Run();
