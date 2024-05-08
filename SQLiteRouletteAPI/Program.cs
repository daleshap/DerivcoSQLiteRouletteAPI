using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using SQLiteRouletteAPI.Data;
using SQLiteRouletteAPI.Interfaces;
using SQLiteRouletteAPI.Repos;

var builder = WebApplication.CreateBuilder(args);

// Configuration
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddNewtonsoftJson();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                          policy =>
                          {
                              policy.AllowAnyOrigin()
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                          });
});


builder.Services.AddScoped<IBetRepository, BetRepository>();
builder.Services.AddScoped<ISpinResultRepository, SpinResultRepository>();
builder.Services.AddScoped<IPayoutRepository, PayoutRepository>();
builder.Services.AddSingleton<GlobalExceptionHandler>();

// Inject IConfiguration
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddDbContext<RouletteDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("RouletteApp")));


var app = builder.Build();


app.UseMiddleware<GlobalExceptionHandler>();
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


public partial class Program { }