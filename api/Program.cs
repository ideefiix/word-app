using Microsoft.EntityFrameworkCore;
using api.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = $"host={builder.Configuration.GetValue<string>("DatabaseSettings:Host")};"
                    + $"port={builder.Configuration.GetValue<string>("DatabaseSettings:Port")};"
                    + $"database={builder.Configuration.GetValue<string>("DatabaseSettings:Database")};"
                    + $"user id={builder.Configuration.GetValue<string>("DatabaseSettings:User")};"
                    + $"password={builder.Configuration.GetValue<string>("DatabaseSettings:Password")};";

builder.Services.AddControllers();
builder.Services.AddDbContext<DBcontext>(options =>
            options.UseNpgsql(connectionString));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "client",
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();

                      });
});

var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("client");
app.UseAuthorization();

app.MapControllers();

app.Run();
