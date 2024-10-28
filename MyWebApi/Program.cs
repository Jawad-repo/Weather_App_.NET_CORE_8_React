using MyClassLib;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:3000", "https://localhost:3000")
             .AllowAnyHeader()
             .AllowAnyMethod();
    });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Enable Cors
app.UseCors("MyCorsPolicy");


app.MapGet("/weatherforecast/{city}", (string city) =>
{
    var weatherService = new WeatherService();
    return weatherService.GetWeatherResponse(city);

})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapGet("/GetDaysWeatherResponse/{city}", (string city) =>
{

    var weatherService = new WeatherService();
    return weatherService.GetDaysWeatherResponse(city);

})
.WithName("GetDaysWeatherResponse")
.WithOpenApi();

app.Run();

