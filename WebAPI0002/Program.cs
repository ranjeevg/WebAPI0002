using WebAPI0002.Extensions;
using WebApi0002.Helpers_and_Enums;
using WebApi0002.Models;
using WebApi0002.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// custom-defined service scoped in - with no helper class needed.
builder.Services.AddScoped<ActualWeatherApiCallsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    app.MapOpenApi();

app.UseHttpsRedirection();

#region API methods

// the default 'get' API that came with the template
app.MapGet("/weatherForecast", () =>
    {
        var forecast = Enumerable.Range(1, AppConstants.MiscConstants.TheAnswerToLifeTheUniverseAndEverything).Select(index =>
            new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                AppConstants.ApiLists.TemperatureDescriptions[Random.Shared.Next(AppConstants.ApiLists.TemperatureDescriptions.Length)]
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

// A sample POST API call, modelled after the sample 'get' API above
app.MapPost("/mostCommonLanguageInCity", () =>
    {
        // declaring an array of 'most common language spoken in the city' results to be returned
        var languagesMostCommonlySpokenInCity = 
            // did not know about this feature for enumerating over a set index
            Enumerable.Range(1, 250)
            .Select(_ => new MostCommonLanguageInCity
            (
                AppConstants.ApiLists.Cities[Random.Shared.Next(AppConstants.ApiLists.Cities.Length)],
                AppConstants.ApiLists.Languages[Random.Shared.Next(AppConstants.ApiLists.Languages.Length)]
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
    .WithName("PostMostCommonLanguageInCity");

// a sample GET method predicting the 'current weather' for a predetermined list of cities.
app.MapGet("/getWeatherForecastByCity", () =>
    {
        var cityList = AppConstants.ApiLists.Cities;
        var weatherDescriptions = AppConstants.ApiLists.TemperatureDescriptions;
        var languagesList = AppConstants.ApiLists.Languages;
        
        // an array of raw data
        WeatherInCity[] rawResponse = 
            Enumerable.Range(1, AppConstants.MiscConstants.TheAnswerToLifeTheUniverseAndEverything)
                // create new objects across the specified numeric range above
                .Select(_ => new WeatherInCity()
                {
                    WeatherDatumDate = DateTime.Today
                        .AddDays(Random.Shared.Next(-2,5))
                        .ToDateOnly(),
                    WeatherDescription = weatherDescriptions[Random.Shared.Next(weatherDescriptions.Length)],
                    CityName = cityList[Random.Shared.Next(cityList.Length)],
                    MostCommonLanguageSpokenInCity = languagesList[Random.Shared.Next(languagesList.Length)]
                })
                // treat each city-date combo as a distinct 'key' to get distinct objects for.
                // test 1 1 2 3
                .ToArray();

        // Format the raw response to the response model.
        // Total data counts are returned as part of the new release model.
        return new WeatherInCityResponseModel
        {
            WeatherDataOrderedByDate = rawResponse
                .GroupBy(datum => datum.WeatherDatumDate)
                .SelectMany(datum => datum)
                .DistinctBy(datum => new {datum.WeatherDatumDate, datum.CityName})
                .OrderByDescending(datum => datum.WeatherDatumDate)
                // then by, in ascending order
                .ThenBy(datum => datum.CityName)
                .AsEnumerable()
        };
    })
    .WithName("GetMostCommonLanguageByCity");

#endregion

app.Run();

