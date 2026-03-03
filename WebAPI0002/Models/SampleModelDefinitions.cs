namespace WebApi0002.Models;

/// <summary>
/// A record to model data from the 'Get Weather Forecast' GET API response.
/// </summary>
/// <param name="Date"></param>
/// <param name="TemperatureC"></param>
/// <param name="Summary">A brief summary of the weather</param>
public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
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
/// record, which is the base response model for the POST API.)
/// </summary>
/// <param name="City"></param>
/// <param name="MostCommonLanguage"></param>
public record MostCommonLanguageInCity(string City, string MostCommonLanguage)
{
}

/// <summary>
/// The response model for the POST API.
/// </summary>
/// <param name="CityData">An IEnumerable of <see cref="MostCommonLanguageInCity"/> objects.</param>
public record MostCommonLanguageResponse(IEnumerable<MostCommonLanguageInCity> CityData)
{
    /// <summary>
    /// A count for the total number of cities returned by the API.
    /// </summary>
    public int CitiesReturnedCount => CityData.Count();
}