using Microsoft.EntityFrameworkCore;
using Student.DataAccess.Abstract;
using Student.DataAccess.Concrete;
using Student.DataAccess.Concrete.MsSql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<StudentDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Local"));
});


builder.Services.AddScoped(typeof(IBaseRepostitory<,>), typeof(EfGenericRepository<,>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
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
