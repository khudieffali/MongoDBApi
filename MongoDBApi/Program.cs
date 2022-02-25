using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDBApi.Models;
using MongoDBApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<EmployeeDatabasesettings>(
          builder.Configuration.GetSection(nameof(EmployeeDatabasesettings)));

builder.Services.AddSingleton<IEmployeeDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<EmployeeDatabasesettings>>().Value);
builder.Services.AddSingleton<IMongoClient>(s =>
     new MongoClient(builder.Configuration.GetValue<string>("EmployeeDatabasesettings:ConnectionString")));
builder.Services.AddScoped<EmployeeService>();

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
