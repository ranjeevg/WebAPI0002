var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

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
    "Icarean", 
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
    "Tagalog"
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
    "New York City"
];

// the default 'get' API that came with the template
app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 10).Select(index =>
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
            Enumerable.Range(1, 10)
            .Select(index => new MostCommonLanguageInCity
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
        return new MostCommonLanguageResponse(languagesMostCommonlySpokenInCity);
    })
    .WithName("PostMostCommonLanguageInCityList");

app.Run();

/// <summary>
/// A record to model data from the 'Get Weather Forecast' GET API response.
/// </summary>
/// <param name="Date"></param>
/// <param name="TemperatureC"></param>
/// <param name="Summary">A brief summary of the weather</param>
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    /// <summary>
    /// This property is auto-generated for the API response, not for use in the program itself.
    /// </summary>
    public int TemperatureF => 32 + TemperatureC / 5 * 9;
}

/// <summary>
/// A record to model date from the 'Most Commonly Spoken Language in City' POST API response.
/// <br /><br />
/// (An IEnumerable of these goes in to the
/// <see cref="MostCommonLanguageResponse">Most Common Language Response</see>
/// record, which is the response for the POST API.)
/// </summary>
/// <param name="City"></param>
/// <param name="MostCommonLanguage"></param>
record MostCommonLanguageInCity(string City, string MostCommonLanguage)
{
}

/// <summary>
/// The response model for the POST API.
/// </summary>
/// <param name="CityData"></param>
record MostCommonLanguageResponse(IEnumerable<MostCommonLanguageInCity> CityData)
{
    /// <summary>
    /// A count for the total number of cities returned by the API.
    /// </summary>
    public int TotalCitiesReturned => CityData.Count();
}