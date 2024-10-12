using System.Text.RegularExpressions;

namespace DateParser.Logic;

public class CalendarDate(int year, int month, int day)
{
    public int Year { get; private set; } = year;
    public int Month { get; private set; } = month;
    public int Day { get; private set; } = day;

    /// <summary>
    /// Parses the given date string into a CalendarDate object.
    /// </summary>
    /// <param name="dateString">Date string to parse</param>
    /// <returns>
    /// Calendar date object
    /// </returns>
    /// <remarks>
    /// Parses a date expression from a string in the format "dd.MM.yyyy".
    /// dd, MM, and yyyy must be numbers. The resulting date must be a valid date.
    /// Note leap years: A year is a leap year if it is divisible by 4.
    /// However, if the year is a century year (ending in 00), it must 
    /// also be divisible by 400 to be a leap year.
    /// Note that you MUST NOT use methods from DateTime or related classes.
    /// </remarks>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown if the date string is empty or the date string does not have a
    /// length of 10 characters.
    /// </exception>
    /// <exception cref="InvalidDateException">
    /// Thrown if the date string is syntactically valid, but the date itself is invalid (e.g. February 30th)
    /// </exception>
    /// <exception cref="FormatException">
    /// Thrown if the date string is not in the expected format
    /// </exception>
    public static CalendarDate Parse(string dateString)
    {
        var date = new CalendarDate(0, 0, 0);

        if (dateString.Length != 10 || string.IsNullOrEmpty(dateString)) { throw new ArgumentOutOfRangeException("Date string has invalid length"); }
        else if (!new Regex(@"^\d{2}\.\d{2}\.\d{4}$").IsMatch(dateString)) { throw new FormatException("Date string has invalid format"); }

        var dateParts = dateString.Split('.');
        var day = int.Parse(dateParts[0]);
        var month = int.Parse(dateParts[1]);
        var year = int.Parse(dateParts[2]);

        if (day < 1 || day > 31 || month < 1 || month > 12 || year < 0 || year > 9999) { throw new InvalidDateException("The date is invalid"); }
        else if (month == 2 && day > 29) // February
        {
            throw new InvalidDateException("February has only 28 or 29 days");
        }
        else if (month == 4 || month == 6 || month == 9 || month == 11) // April, June, September, November
        {
            if (day > 30) { throw new InvalidDateException("April, June, September, November have only 30 days"); }
        }
        if (month == 2 && day == 29 && year % 4 != 0) // Leap year
        { 
            throw new InvalidDateException("February 29th is only valid in leap years"); 
        }
        if (month == 2 && day == 29 && year % 100 == 0 && year % 400 != 0) // Not a leap year because it's a century year
        { 
            throw new InvalidDateException("February 29th is only valid in leap years"); 
        }

        date.Year = year;
        date.Month = month;
        date.Day = day;

        return date;
    }
}

public static class CalendarResponseBuilder
{
    /// <summary>
    /// Tries to parse the given date string and returns a response string.
    /// </summary>
    /// <param name="date">Date string to parse</param>
    /// <returns>
    /// One of the following responses:
    /// - "The date is valid. It is the dd.MM.yyyy." (replace dd, MM, yyyy with the actual date)
    /// - "Date string has invalid length" (in case of ArgumentOutOfRangeException)
    /// - "Date string has invalid format" (in case of FormatException)
    /// - "The date is invalid" (in case of InvalidDateException)
    /// </returns>
    public static string BuildResponse(string dateString)
    {
        try
        {
            var date = CalendarDate.Parse(dateString);
            return $"The date is valid. It is the {date.Day:D2}.{date.Month:D2}.{date.Year:D4}.";
        }
        catch (ArgumentOutOfRangeException)
        {
            return "Date string has invalid length";
        }
        catch (FormatException)
        {
            return "Date string has invalid format";
        }
        catch (InvalidDateException)
        {
            return "The date is invalid";
        }
        catch (Exception)
        {
            throw; // rethrow any other exceptions
        }
    }
}

public class InvalidDateException : Exception
{
    public InvalidDateException() { }

    public InvalidDateException(string message) : base(message) { }

    public InvalidDateException(string message, Exception innerException) : base(message, innerException) { }
}
