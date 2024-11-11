using MyClassLib;


// Add services to the container.

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:3000", "https://localhost:3000")
             .AllowAnyHeader()
             .AllowAnyMethod();
    });
});

builder.Services.AddSingleton<WeatherService>();


// Configure the HTTP request pipeline.

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable CORS
app.UseCors("MyCorsPolicy");


app.MapGet("/weatherforecast/{city}", (string city, WeatherService weatherService) =>
{

    return weatherService.GetWeatherResponse(city);

})
.WithName("GetWeatherForecast");

app.MapGet("/GetDaysWeatherResponse/{city}", (string city, WeatherService weatherService) =>
{

    return weatherService.GetDaysWeatherResponse(city);

})
.WithName("GetDaysWeatherResponse");

app.Run();

