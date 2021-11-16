using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace System
{
    public static class StringHelpers
    {
        static Random random_ = new Random();
        static Regex? pascalRegex_;
        static StringBuilder? stringBuilder_;

#pragma warning disable CS8603

        /// <summary>
        /// This is intended as a replacement for using Guids. Useful for generating random id's on input and associated label elements, passwords, Entity Id's. NOTE: This uses System.Random, not System.Security.Cryptography.RandomNumberGenerator
        /// </summary>
        /// <param name="length">How long the returned string will be. Default is 11</param>
        /// <param name="specialCharacters">The special characters to include. Default is </param>
        /// <param name="excludeConfusingCharacters">If true, characters such as 0, O and l, 1, I are excluded.</param>
        /// <returns></returns>
        public static string GenerateRandomString_Mt(this string? s, int length = 11, string? specialCharacters = "!@#$%^&*()[]{}<>?", bool excludeConfusingCharacters = true)
        {
            string alphanumerics;

            if (excludeConfusingCharacters)
            {
                alphanumerics = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz23456789";
            }
            else
            {
                alphanumerics = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            }

            string pickFrom;

            if (string.IsNullOrWhiteSpace(specialCharacters)) pickFrom = alphanumerics;
            else pickFrom = alphanumerics + specialCharacters;

            int pickFromLength = pickFrom.Length;

            if (stringBuilder_ == null) stringBuilder_ = new StringBuilder();
            else stringBuilder_.Clear();

            for (int i = 0; i < length; i++)
            {
                if(i == 0) //make the first char alphanumeric
                {
                    stringBuilder_.Append(alphanumerics[random_.Next(0, alphanumerics.Length)]);
                    continue;
                }
                stringBuilder_.Append(pickFrom[random_.Next(0, pickFromLength)]);
            }

            return stringBuilder_.ToString();
        }

        /// <summary>
        /// Removes extra whitespace and tabs
        /// </summary>
        public static string RemoveExtraWhiteSpaces_Mt(this string? s)
        {
            if (s == null) return s;

            if (stringBuilder_ == null) stringBuilder_ = new StringBuilder(s.Length);
            else stringBuilder_.Clear();

            int i = 0;
            foreach (char c in s)
            {
                if (c != ' ' || i == 0 || s[i - 1] != ' ')
                    stringBuilder_.Append(c);
                i++;
            }
            return stringBuilder_.ToString();
        }

        /// <summary>
        /// Replaces whitespace with characters provided
        /// </summary>
        /// <param name="replacement">What to replace whitespace with</param>
        public static string ReplaceWhitespace_Mt(this string? s, string replacement)
        {
            if (s == null) return s;
            return string.Join(replacement, s.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
        }

        /// <summary>
        /// Shortens string to specified length
        /// </summary>
        /// <param name="maxLength">Max length the returned string should be</param>
        /// <param name="addEllipses">Optionally add ellipses. Default is true</param>
        public static string Shorten_Mt(this string? s, int maxLength, bool addEllipses = true)
        {
            if (s == null || s.Length <= maxLength) return s;

            if (addEllipses) return s.Substring(0, maxLength - 3) + "...";

            return s.Substring(0, maxLength);
        }

        /// <summary>
        /// Strips html from string. Not sure how robust this is.
        /// </summary>
        public static string StripHtml_Mt(this string? s)
        {
            if (s == null) return s;
            return Regex.Replace(s, "<.*?>", String.Empty);
        }

        /// <summary>
        /// Turn a Pascal cased property name, "MyAwesomeProperty" to "My Awesome Property"
        /// </summary>
        public static string ToWords_Mt(this string? s)
        {
            if (s == null) return s;

            if (pascalRegex_ == null) pascalRegex_ = new Regex(@"
        (?<=[A-Z])(?=[A-Z][a-z]) |
         (?<=[^A-Z])(?=[A-Z]) |
         (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);

            return pascalRegex_.Replace(s, " ");
        }

        /// <summary>
        /// Url encodes a string
        /// </summary>
        public static string UrlEncode_Mt(this string? s)
        {
            if (string.IsNullOrWhiteSpace(s)) return s;
            return WebUtility.UrlEncode(s);
        }

#pragma warning restore CS8603
    }
}