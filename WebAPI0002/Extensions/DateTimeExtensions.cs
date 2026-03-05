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

    /// <summary>
    /// An extension method extending the inbuilt AddDays() method.
    /// </summary>
    /// <param name="dateTime"></param>
    /// <param name="days"></param>
    /// <returns></returns>
    public static DateTime SubtractDays(this DateTime dateTime, int days)
        => dateTime.AddDays(days * -1);
    
    /// <summary>
    /// Similar to the .AddDays() method inbuilt for DateTimes on C#.
    /// </summary>
    /// <param name="dateTime"></param>
    /// <param name="days"></param>
    /// <returns></returns>
    public static DateTime SubtractDays(this DateTime dateTime, double days)
        => dateTime.AddDays(days * -1);

    /// <summary>
    /// Returns the Monday of the week that
    /// <paramref name="dateTime">dateTime</paramref>
    /// falls on.
    /// </summary>
    /// <param name="dateTime"></param>
    /// <remarks>
    /// <i>
    /// (Peering in to the source code for DateTimes, we note that
    /// {Sunday : Saturday} is isomorphic to {0 : 6}.
    /// <br /><br />
    /// We use that to calculate the date value.)
    /// </i>
    /// </remarks>
    public static int GetMondayOfWeek(this DateTime dateTime)
    {
        int MondayOfWeek;
        
        // Given that same isomrphism, Monday maps over to 1. 
        

        throw new NotImplementedException("");
    }
}