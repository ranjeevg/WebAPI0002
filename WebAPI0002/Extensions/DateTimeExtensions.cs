namespace WebApi0002.Extensions;

public static class DateTimeExtensions
{
    /// <summary>
    /// An extension method to convert DateTimes to DateOnly's.
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static DateOnly ToDateOnly(this DateTime dateTime)
    {
        DateOnly dateOnly = new(year: dateTime.Year, month:dateTime.Month, day: dateTime.Day);

        return dateOnly;
    }
}