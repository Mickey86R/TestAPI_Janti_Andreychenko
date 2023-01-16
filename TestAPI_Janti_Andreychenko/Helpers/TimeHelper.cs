namespace TestAPI_Janti_Andreychenko.Helpers
{
    public class TimeHelper : ITimeHelper
    {
        // Получает строку, описывающую часовой пояс, т.н. ZZZZ (прим.: +0400/-0300)
        public static string GetTimeOffsetFromCurrentTimeZone(TimeZoneInfo currentTimeZone)
        {
            var offset = currentTimeZone.BaseUtcOffset.ToString();

            offset = offset.Replace(":", "");

            var result = offset.Remove(offset.Length - 2);

            return result;
        }

        // Преобразует введённую строку во время по UTC
        public static DateTime ConvertTimeUTCFromString(string time)
        {
            var timeParameters = new List<string>();

            // Разбиение строки на параметры
            if (time.Contains('/'))
                timeParameters = time.Split('/', '-', ' ').ToList();
            else
                timeParameters = time.Split('.', ':', ' ').ToList();

            // Создание DateTime из полученных параметров
            DateTime resultDateTime;
            int length = timeParameters.Count;
            if (length >= 6)
                resultDateTime = new DateTime(Convert.ToInt32(timeParameters[2]),
                                            Convert.ToInt32(timeParameters[1]),
                                            Convert.ToInt32(timeParameters[0]),
                                            Convert.ToInt32(timeParameters[3]),
                                            Convert.ToInt32(timeParameters[4]),
                                            Convert.ToInt32(timeParameters[5]),
                                            DateTimeKind.Utc);

            else
                resultDateTime = new DateTime(Convert.ToInt32(timeParameters[2]),
                                            Convert.ToInt32(timeParameters[1]),
                                            Convert.ToInt32(timeParameters[0]),
                                            Convert.ToInt32(timeParameters[3]),
                                            Convert.ToInt32(timeParameters[4]),
                                            0,
                                            DateTimeKind.Utc);

            // Если есть параметр часового пояса, находим разницу заданного часового пояса с UTC
            // и преобразуем заданное время в UTC
            if (timeParameters.Count == 7)
            {
                var offset = GetTimeOffsetFromString(timeParameters.Last());
                resultDateTime = resultDateTime.Add(offset);
            }

            return resultDateTime;
        }

        // Получение TimeSpan указанного часового пояса
        // Тут + и - меняются местами, потому что у нас есть возможность только добавить время
        public static TimeSpan GetTimeOffsetFromString(string time)
        {
            bool isNegative;

            if (char.IsDigit(time[0]))
                isNegative = false;
            else
            {
                if (time[0] == '+')
                    isNegative = false;
                else
                    isNegative = true;

                time = time.Remove(0, 1);
            }

            var HH = Convert.ToInt32(time.Substring(0, 2));
            var mm = Convert.ToInt32(time.Substring(2, 2));

            var result = default(TimeSpan);
            result = TimeSpan.FromHours(HH) + TimeSpan.FromMinutes(mm);

            if (isNegative)
                return result;

            result = TimeSpan.Zero - result;
            return result;
        }

        // Получение строки, описывающей текущее вермя в необходимом формате с CurrentTimeZone
        public static string GetTimeInCurrentTimeZone(DateTime time, TimeZoneInfo currentTimeZone)
        {
            var newTime = TimeZoneInfo.ConvertTime(time, currentTimeZone).ToString();

            var result = $"{newTime} {TimeHelper.GetTimeOffsetFromCurrentTimeZone(currentTimeZone)}";

            return result;
        }
    }
}
