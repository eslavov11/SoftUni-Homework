using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// A static utility class, containing parse and conversion methods
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Convert a input string to a byte array and compute the hash.
    /// </summary>
    /// <param name="input">Input string.</param>
    /// <returns>Hexadecimal string.</returns>
    public static string ToMd5Hash(this string input)
    {
        var md5Hash = MD5.Create();
        var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
        var builder = new StringBuilder();

        for (int i = 0; i < data.Length; i++)
        {
            builder.Append(i.ToString("x2"));
        }

        return builder.ToString();
    }

    /// <summary>
    /// Method which returns whether a string has a truthy value.
    /// </summary>
    /// <param name="input">Input string.</param>
    /// <returns>bool</returns>
    public static bool ToBoolean(this string input)
    {
        var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
        return stringTrueValues.Contains(input.ToLower());
    }

    /// <summary>
    /// Method which tries to parse a string to short (16-bit integer) and returns 0 if the operation failed.
    /// </summary>
    /// <param name="input">Input string.</param>
    /// <returns>returns the value as 16 bit integer or 0 if parse was not successful.</returns>
    public static short ToShort(this string input)
    {
        short shortValue;
        short.TryParse(input, out shortValue);
        return shortValue;
    }

    /// <summary>
    /// Method which tries to parse a string to int (32-bit integer) and returns 0 if the operation failed.
    /// </summary>
    /// <param name="input">Input string.</param>
    /// <returns>Returns the value as 32 bit integer or 0 if parse was not successful.</returns>
    public static int ToInteger(this string input)
    {
        int integerValue;
        int.TryParse(input, out integerValue);
        return integerValue;
    }

    /// <summary>
    /// Method which tries to parse a string to long (64-bit integer) and returns 0 if the operation failed.
    /// </summary>
    /// <param name="input">Input string.</param>
    /// <returns>Returns the value as 64 bit integer or 0 if parse was not successful.</returns>
    public static long ToLong(this string input)
    {
        long longValue;
        long.TryParse(input, out longValue);
        return longValue;
    }

    /// <summary>
    /// Method which tries to parse a string to DateTime format and returns null if the operation failed
    /// </summary>
    /// <param name="input">Input string.</param>
    /// <returns>returns DateTime or null if parse was not successful</returns>
    public static DateTime ToDateTime(this string input)
    {
        DateTime dateTimeValue;
        DateTime.TryParse(input, out dateTimeValue);
        return dateTimeValue;
    }

    /// <summary>
    /// Sets the first letter of a string as uppercase
    /// </summary>
    /// <param name="input">Input string.</param>
    /// <returns>the string with a capitalized first letter</returns>
    public static string CapitalizeFirstLetter(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        return
            input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) +
            input.Substring(1, input.Length - 1);
    }

    /// <summary>
    /// Returns a substring which is between a start string and end string starting from a given index
    /// </summary>
    /// <param name="input">initial string</param>
    /// <param name="startString">start string</param>
    /// <param name="endString">the end of the substring</param>
    /// <param name="startFrom">start index</param>
    /// <example>
    /// <code>
    /// string substring = GetStringBetween("123456789", "23", "78", 2);
    /// Console.WriteLine(substring); /* Displays "6" */
    /// </code>
    /// </example>
    /// <returns>the substring located between the start and end string</returns>
    public static string GetStringBetween(
        this string input, string startString, string endString, int startFrom = 0)
    {
        input = input.Substring(startFrom);
        startFrom = 0;
        if (!input.Contains(startString) || !input.Contains(endString))
        {
            return string.Empty;
        }

        var startPosition =
            input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
        if (startPosition == -1)
        {
            return string.Empty;
        }

        var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
        if (endPosition == -1)
        {
            return string.Empty;
        }

        return input.Substring(startPosition, endPosition - startPosition);
    }

    /// <summary>
    /// Method which converts cyrillic string to latin one
    /// </summary>
    /// <param name="input">cyrillic string</param>
    /// <returns>returns latin string</returns>
    public static string ConvertCyrillicToLatinLetters(this string input)
    {
        var bulgarianLetters = new[]
        {
            "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о",
            "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
        };
        var latinRepresentationsOfBulgarianLetters = new[]
        {
            "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
            "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
            "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
        };
        for (var i = 0; i < bulgarianLetters.Length; i++)
        {
            input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
            input = input.Replace(
                bulgarianLetters[i].ToUpper(),
                latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
        }

        return input;
    }

    /// <summary>
    /// Method which converts latin string to cyrillic one
    /// </summary>
    /// <param name="input">latin string</param>
    /// <returns>returns cyrillic string</returns>
    public static string ConvertLatinToCyrillicKeyboard(this string input)
    {
        var latinLetters = new[]
        {
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
            "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
        };

        var bulgarianRepresentationOfLatinKeyboard = new[]
        {
            "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
            "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
            "в", "ь", "ъ", "з"
        };

        for (int i = 0; i < latinLetters.Length; i++)
        {
            input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
            input = input.Replace(
                latinLetters[i].ToUpper(),
                bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
        }

        return input;
    }

    /// <summary>
    /// Method which converts invalid non-latin username to a latin one
    /// </summary>
    /// <param name="input">initial username</param>
    /// <returns>the valid latin username as a string</returns>
    public static string ToValidUsername(this string input)
    {
        input = input.ConvertCyrillicToLatinLetters();
        return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
    }

    /// <summary>
    /// Method which replaces invalid non-latin file name with lattin letters
    /// </summary>
    /// <param name="input">initial file name</param>
    /// <returns>the valid file name as a string</returns>
    public static string ToValidLatinFileName(this string input)
    {
        input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
        return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
    }

    /// <summary>
    /// Method which returns the first desired characters from a string as a string
    /// </summary>
    /// <param name="input">the string from which the characters are taken</param>
    /// <param name="charsCount">number of chars to return</param>
    /// <returns>returns a string consisting of the first n characters from the input</returns>
    public static string GetFirstCharacters(this string input, int charsCount)
    {
        return input.Substring(0, Math.Min(input.Length, charsCount));
    }

    /// <summary>
    /// Method which returns file extension as a string
    /// </summary>
    /// <param name="fileName">The full name of the file</param>
    /// <returns>file extension as a string</returns>
    public static string GetFileExtension(this string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
        {
            return string.Empty;
        }

        string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
        if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
        {
            return string.Empty;
        }

        return fileParts.Last().Trim().ToLower();
    }

    /// <summary>
    /// A static method which returns the content type of an extension
    /// </summary>
    /// <param name="fileExtension"></param>
    /// <returns>returns content type as a string</returns>
    public static string ToContentType(this string fileExtension)
    {
        var fileExtensionToContentType = new Dictionary<string, string>
        {
            { "jpg", "image/jpeg" },
            { "jpeg", "image/jpeg" },
            { "png", "image/x-png" },
            { "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
            { "doc", "application/msword" },
            { "pdf", "application/pdf" },
            { "txt", "text/plain" },
            { "rtf", "application/rtf" }
        };

        if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
        {
            return fileExtensionToContentType[fileExtension.Trim()];
        }

        return "application/octet-stream";
    }

    /// <summary>
    /// Method which converts a string to byte array
    /// </summary>
    /// <param name="input">string which is converted to byte array</param>
    /// <returns>byte array</returns>
    public static byte[] ToByteArray(this string input)
    {
        var bytesArray = new byte[input.Length * sizeof(char)];
        Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
        return bytesArray;
    }
}
