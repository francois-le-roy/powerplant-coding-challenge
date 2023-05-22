using powerplant_coding_challenge_implementation.Services;
using powerplant_coding_challenge_implementation.Services.Interfaces;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
                //convert strings to enums
                .AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters
                .Add(new JsonStringEnumConverter()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IMeritOrderCalculator, MeritOrderCalculator>();
builder.Services.AddScoped<ILoadAssignor, LoadAssignor>();
builder.Services.AddSwaggerGen();

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
