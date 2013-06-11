using System;

namespace Core.Extensions
{
    public static class DateTimeExtensions
    {
         public static string ToApiDateTimeFormat(this DateTime value)
         {
             return value.ToString("dd/MM/yyyy HH:mm:ss");
         }
    }
}