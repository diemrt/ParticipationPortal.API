using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticipationPortal.Services.Common
{
    public static class DateTimeUtils
    {
        /// <summary>
        /// Get the date time of the closest day of the week expected
        /// </summary>
        /// <param name="startingDate">the given date time</param>
        /// <param name="expectedDayOfTheWeek">the day of the week type</param>
        public static DateTime GetNextDateOfTheWeek(DateTime startingDate, DayOfWeek expectedDayOfTheWeek)
        {
            while (startingDate.DayOfWeek != expectedDayOfTheWeek)
                startingDate = startingDate.AddDays(1);

            return startingDate;
        }
    }
}
