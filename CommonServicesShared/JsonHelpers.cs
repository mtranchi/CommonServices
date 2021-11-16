using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace System
{
    public static class JsonHelpers
    {
        public static string ToJson_Mt(this object obj, bool writeIndented = false)
        {
#pragma warning disable CS8603 // Possible null reference return.
            if (obj is null) return null;
#pragma warning restore CS8603 // Possible null reference return.

            return JsonSerializer.Serialize(obj, new JsonSerializerOptions
            {
                WriteIndented = writeIndented,
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            });
        }

        public static T? FromJson_Mt<T>(this string? json)
        {
            if(string.IsNullOrEmpty(json)) return default;

            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
        }
    }
}
