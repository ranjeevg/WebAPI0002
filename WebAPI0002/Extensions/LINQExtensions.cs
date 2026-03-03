using System;
using System.Collections.Generic;
using System.Linq;
using WebApi0002.Models;

namespace WebApi0002.Extensions;

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
