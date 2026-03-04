namespace WebApi0002.Extensions;

public static class DateTimeExtensions
{
    /// <summary>
    /// A simple extension method to convert DateTimes to DateOnly's.
    /// </summary>
    /// <param name="dateTime">
    /// The <see cref="DateTime"/> object to convert into a DateOnly.
    /// </param>
    /// <returns></returns>
    public static DateOnly ToDateOnly(this DateTime dateTime)
        => new(year: dateTime.Year, month:dateTime.Month, day: dateTime.Day);
}