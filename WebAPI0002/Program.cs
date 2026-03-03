using WebApi0002.Extensions;
using WebAPI0002.Helpers_and_Enums;
using WebApi0002.Models;
using WebApi0002.Services;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// custom-defined service scoped in - with no helper class needed.
builder.Services.AddScoped<Services>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Local weather condition summaries
string[] summaries =
[
    "Freezing", 
    "Bracing", 
    "Chilly", 
    "Cool", 
    "Mild", 
    "Warm", 
    "Balmy", 
    "Hot", 
    "Sweltering", 
    "Scorching", 
    "Boiling", 
    "Judeccan"
];

// dummy values for languages
string[] languages =
[   
    "English", 
    "Tamil", 
    "Hindi", 
    "French", 
    "Spanish", 
    "Mandarin", 
    "Japanese", 
    "Punjabi", 
    "Urdu", 
    "Sinhala", 
    "Danish", 
    "Norwegian", 
    "Swedish", 
    "Finnish", 
    "Igbo",
    "Tagalog",
    "Dene",
    "Malayalam",
    "Russian",
    "Ukrainian",
    "Sanskrit"
];

// a list of dummy values for cities
string[] cities =
[
    "Vancouver", 
    "Surrey", 
    "Toronto", 
    "Bangalore", 
    "Delhi", 
    "Madrid", 
    "Rome", 
    "Bern", 
    "Trondheim",
    "Calgary",
    "Edmonton",
    "Kamloops",
    "Montreal",
    "Hyderabad",
    "Udupi", 
    "Havana",
    "New York City",
    "Varanasi"
];

#region API methods

// the default 'get' API that came with the template
app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 100).Select(index =>
            new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            ))
        .ToArray();
        
        // removing duplicate dates
        // (redundant in this method, present as an example only)
        forecast = forecast
            .DistinctBy(datum => datum.Date)
            .ToArray();
        
        return forecast;
    })
    .WithName("GetWeatherForecast");

// A sample POST API call, modeled after the sample 'get' API above
app.MapPost("/mostCommonLanguageInCityList", () =>
    {
        // declaring an array of 'most connon language spoken in the city' results to be returned
        var languagesMostCommonlySpokenInCity = 
            // did not know about this feature for enumerating over a set index
            Enumerable.Range(1, 100)
            .Select(_ => new MostCommonLanguageInCity
            (
                cities[Random.Shared.Next(cities.Length)],
                languages[Random.Shared.Next(languages.Length)]
            ))
            .ToArray();
        
        // removing duplicates by city
        languagesMostCommonlySpokenInCity = languagesMostCommonlySpokenInCity
            .DistinctBy(datum => datum.City)
            .ToArray();
        
        // returning a response object, with the distinct cities and a summary line.
        var respRaw = new MostCommonLanguageResponse(languagesMostCommonlySpokenInCity);

        var response = respRaw.OrderByCityNameAlphabetically(respRaw);

        return response;
    })
    .WithName("PostMostCommonLanguageInCityList");

#endregion

app.Run();

