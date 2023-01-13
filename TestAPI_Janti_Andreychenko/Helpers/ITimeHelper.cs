namespace TestAPI_Janti_Andreychenko.Helpers
{
    public interface ITimeHelper
    {
        // Служит для преобразования формата часового пояса из Olson в TimeZoneInfo
        private static TimeZoneInfo OlsonTimeZoneToTimeZoneInfo(string olsonTimeZoneId) => TimeZoneInfo.Utc;

        // Получает строку, описывающую часовой пояс, т.н. ZZZZ (прим.: +0400/-0300)
        private static string GetTimeOffsetFromCurrentTimeZone(TimeZoneInfo currentTimeZone) => string.Empty;

        // Преобразует введённую строку во время по UTC
        private static DateTime ConvertTimeUTCFromString(string time) => DateTime.Now.ToUniversalTime();

        // Получение TimeSpan указанного часового пояса
        // Тут + и - меняются местами, потому что у нас есть возможность только добавить время
        private static TimeSpan GetTimeOffsetFromString(string time) => TimeSpan.Zero;

        // Получение строки, описывающей текущее вермя в необходимом формате с CurrentTimeZone
        private static string GetTimeInCurrentTimeZone(DateTime time, TimeZoneInfo currentTimeZone) => string.Empty;
    }
}
