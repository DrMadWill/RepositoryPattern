using Microsoft.EntityFrameworkCore;
using Student.DataAccess.Abstract;
using Student.DataAccess.Concrete;
using Student.DataAccess.Concrete.MsSql;
using Student.Api.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => new OpenApiInfo
{
    Version = "v1",
    Title = "Students Course Api",
    Description = "Students Detail Data",
    TermsOfService = new Uri("https://github.com/DrMadWill/RepositoryPattern"),
    Contact = new OpenApiContact
    {
        Name = "Nofel Salahov (DR Mad Will)",
        Email = "nofelsalahov9@gmail.com",
        Url = new Uri("https://www.linkedin.com/in/drmadwill/")
    }
});


builder.Services.AddDbContext<StudentDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Local"));
});

builder.Services.RegisterAppServices();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Repository Pattern API V1");
    c.RoutePrefix = String.Empty;
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
