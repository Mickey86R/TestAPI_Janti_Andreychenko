using TestAPI_Janti_Andreychenko.Helpers;

namespace TestAPI_Janti_Andreychenko.Services
{
    public class TimeManager : ITimeManager
    {
        private static TimeZoneInfo currentTimeZone = TimeZoneInfo.Utc;


        //---------------------------------------------ОСНОВНЫЕ МЕТОДЫ


        // Возвращает текущую дату согласно значению CurrentTimeZone
        public string GetTime()
        {
            return TimeHelper.GetTimeInCurrentTimeZone(DateTime.Now, currentTimeZone);
        }

        // Устанавливает значение CurrentTimeZone
        public bool SetTimeZone(string time)
        {
            var newTimeZone = default(string);

            var result = TimeZoneConverter.TZConvert.TryIanaToWindows(time, out newTimeZone);

            if (result)
                currentTimeZone = TimeZoneInfo.GetSystemTimeZones().First(tz => tz.Id == newTimeZone);

            return result;
        }

        // Преобразует заданную строку со временем в CurrentTimeZone и возвращает её, иначе возвращает пустую строку
        public string ConvertDate(string time)
        {
            string result = "";

            try
            {
                var timeFromString = TimeHelper.ConvertTimeUTCFromString(time);
                result = TimeHelper.GetTimeInCurrentTimeZone(timeFromString, currentTimeZone);
            }
            catch { }


            return result;
        }
    }
}
