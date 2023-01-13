namespace TestAPI_Janti_Andreychenko.Services
{
    public interface ITimeManager
    {
        // Возвращает текущую дату согласно значению CurrentTimeZone
        public string GetTime() => string.Empty;

        // Устанавливает значение CurrentTimeZone
        public bool SetTimeZone(string time) => false;

        // Преобразует заданную строку со временем в CurrentTimeZone и возвращает её, иначе возвращает пустую строку
        public string ConvertDate(string time) => string.Empty;
    }
}
