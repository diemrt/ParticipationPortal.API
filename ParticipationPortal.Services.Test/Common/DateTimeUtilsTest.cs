using ParticipationPortal.Services.Common;

namespace ParticipationPortal.Services.Test.Common
{
    public class DateTimeUtilsTest
    {
        [Fact]
        public void GetNextDateOfTheWeek_CorrectNextFriday()
        {
            var startingDate = DateTime.Today;
            var expectedDayOfTheWeek = DayOfWeek.Friday;

            var result = DateTimeUtils.GetNextDateOfTheWeek(startingDate, expectedDayOfTheWeek);
            Assert.True(result == new DateTime(2022, 10, 21));
        }

        [Fact]
        public void GetNextDateOfTheWeek_CorrectNextFridayOfTheMonth()
        {
            var startingDate = DateTime.Today;
            var lastDayOfTheMonth = DateTime.DaysInMonth(startingDate.Year, startingDate.Month);
            var endingDate = new DateTime(startingDate.Year, startingDate.Month, lastDayOfTheMonth);
            var expectedDayOfTheWeek = DayOfWeek.Friday;
            var result = new List<DateTime>();

            while (startingDate < endingDate)
            {
                result.Add(DateTimeUtils.GetNextDateOfTheWeek(startingDate, expectedDayOfTheWeek));
                startingDate = startingDate.AddDays(7);
            }

            Assert.True(lastDayOfTheMonth == 31);
            Assert.True(endingDate == new DateTime(2022, 10, 31));
        }
    }
}