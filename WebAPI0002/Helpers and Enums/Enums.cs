namespace WebAPI0002.Helpers_and_Enums;

/// <summary>
/// Primarily a logical 'reserved spot', as it were, for enums.
/// </summary>
public static class Enums
{
    /// <summary>
    /// What are we looking at when we want to order an IEnumerable of a given type T using this extension method?
    /// </summary>
    public enum OrderingType
    {
        ByObjectNameLiteral,
        /// <summary>
        /// .NET 10 just introduced the .DistinctBy() LINQ method, as a reference.
        /// </summary>
        BySpecificProperty
    }
}