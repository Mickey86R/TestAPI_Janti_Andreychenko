
namespace TestAPI_Janti_Andreychenko
{
    public class TimeManager
    {
        private static TimeZoneInfo currentTimeZone;

        public TimeManager()
        {
            currentTimeZone = TimeZoneInfo.Utc;
        }

        public async Task<string> GetTime()
        {
            string result = "";



            return result;
        }

        public async Task<bool> SetTimeZone(string time)
        {
            var result = true;

            return result;
        }

        public async Task<string> ConvertDate(string time)
        {
            string result = "";

            return result;
        }
    }
}
