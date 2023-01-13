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
            bool result;

            var newTimeZone = TimeHelper.OlsonTimeZoneToTimeZoneInfo(time);

            if (newTimeZone != null)
            {
                currentTimeZone = TimeHelper.OlsonTimeZoneToTimeZoneInfo(time);
                result = true;
            }
            else
                result = false;

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
