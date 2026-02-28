using System;
using System.Collections.Generic;

namespace WebApi0002.Extensions;

public static class ResponseExtensions
{
    /// <summary>
    /// Sorts the results of a
    /// <see cref="MostCommonLanguageResponse"/>
    /// by city name in alphabetical order.
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static MostCommonLanguageResponse OrderByCityNameAlphabetically(this MostCommonLanguageResponse source) => 
        new MostCommonLanguageResponse(source.CityData.OrderBy(datum => datum.City));
}