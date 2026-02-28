using System;
using System.Collections.Generic;
using WebApi0002.Models;

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

public static class LinqExtensions
{
    /// <summary>
    /// Order the IEnumerable alphabetically.
    /// </summary>
    /// <param name="source">The original IEnumerable.</param>
    /// <typeparam name="T">The class type being referred to here.</typeparam>
    /// <returns>A new IEnumerable of type T, ordered alphabetically.</returns>
    /// <exception cref="NotImplementedException"></exception>
    public static IEnumerable<T> OrderAlphabetically<T>(this IEnumerable<T> source) where T : class
    {
        throw new NotImplementedException("FYI. In progress.");
    }
}
