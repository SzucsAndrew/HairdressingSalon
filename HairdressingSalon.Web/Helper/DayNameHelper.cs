using System;
namespace HairdressingSalon.Web.Helper
{
    public static class DayNameHelper
    {
        private static string[] DayNames =
        {
            "Week","Monday","Tuesday","Wednesday","Thursday","Friday","Saturday","Sunday"
        };

        public static string GetDayName(int index)
        {
            if (index >= DayNames.Length) return "Invalid day";
            return DayNames[index];
        }

        public static int GetDayIndex(string name)
        {
            return Array.IndexOf(DayNames, name);
        }
    }
}
