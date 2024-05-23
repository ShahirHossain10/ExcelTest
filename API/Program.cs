using Infrastructure.Data;
using Application;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var origin = "_specificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(origin, policy =>
    {
        policy.WithOrigins("http://localhost:5187", "https://localhost:7098")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
    });
});


builder.Services.AddSwaggerGen();

var dbConnectionString = builder.Configuration.GetConnectionString("DbConnection");
builder.Services.AddDbContextPool<DataContext>(options => options.UseSqlServer(dbConnectionString));

builder.Services.AddApplicationServices();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(origin);
app.MapControllers();

app.Run();
