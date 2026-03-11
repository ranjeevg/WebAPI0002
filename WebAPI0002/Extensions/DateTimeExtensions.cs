namespace WebAPI0002.Extensions;

public static class Extensions
{
    public static DateTime SubtractDays(this DateTime date, int days)
        => date.AddDays(-1 * days);

    /// <summary>
    /// Determine if this case is relevant.
    /// </summary>
    /// <param name="date"></param>
    /// <param name="days"></param>
    /// <returns></returns>
    public static DateTime SubtractDays(this DateTime date, double days)
        => date.AddDays(-1 * days);

    /// <summary>
    /// Returns the Monday of the week that
    /// <paramref name="dateTime">dateTime</paramref>
    /// falls on.
    /// </summary>
    /// <param name="dateTime"></param>
    /// <remarks>
    /// <i>
    /// Peering in to the source code for DateTimes, we note that
    /// <br />
    /// <b>{Sunday : Saturday}</b> is isomorphic to <b>{0 : 6}</b>.
    /// <br /><br />
    /// We use that to calculate the date value.
    /// </i>
    /// </remarks>
    public static DateTime GetMondayOfWeek(this DateTime dateTime)
    {
        int difference;
        
        // Given that same isomorphism, Monday maps over to 1. 
        // Letting the current day of the week be represented by d, and x represent the number of days to be added / subtracted to get that date,
        // it follows that
        // 1 + x = d
        // => x = d - 1
        difference = (int)dateTime.DayOfWeek - 1;

        return dateTime.SubtractDays(difference);
    }

    /// <summary>
    /// A generalization of the
    /// <b><i>GetMondayOfWeek()</i></b>
    /// extension method in this library, <br/>
    /// to find the datetime for any day in the week that <paramref name="dateTime"/> occurs in.
    /// </summary>
    /// <param name="dateTime"></param>
    /// <param name="dayOfWeekIndex"></param>
    public static DateTime GetNthDayOfWeek(this DateTime dateTime, int dayOfWeekIndex)
    {
        var difference = (int)dateTime.DayOfWeek - dayOfWeekIndex;

        return dateTime.SubtractDays(difference);
    }

    /// <summary>
    /// An overload of the
    /// <see cref="Extensions.GetNthDayOfWeek(this DateTime dateTime, int dayOfWeek)">
    /// GetMondayOfWeek
    /// </see>
    /// method, using DateTimes instead of raw int values.
    /// </summary>
    /// <param name="dateTime"></param>
    /// <param name="dayOfWeek"></param>
    /// <returns></returns>
    public static DateTime GetNthDayOfWeek(this DateTime dateTime, DayOfWeek dayOfWeek)
    {
        int dayOfWeekRaw = (int)dayOfWeek;
        int difference = dateTime.DayOfWeek - dayOfWeek;

        return dateTime.SubtractDays(difference);
    }
    
    /// <summary>
    /// This might already be an existing functionality, but adding this method for ease of use.
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static DateOnly ToDateOnly(this DateTime date)
        => new (date.Year, date.Month, date.Day);
}