using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Data;
using System.Globalization;
using TestAPI_Janti_Andreychenko.Services;

namespace TestAPI_Janti_Andreychenko.Controllers
{
    [Route("/TimeManager/")]
    [ApiController]
    public class TimeController : Controller
    {
        private ITimeManager _timeManager;

        public TimeController(ITimeManager timeManager)
        {
            _timeManager = timeManager;
        }


        //-----------------------------------GET

        // Возвращает текущую дату согласно значению CurrentTimeZone
        [Route("GetTime")]
        [HttpGet]
        public async Task<ActionResult<string>> GetTime()
        {
            return _timeManager.GetTime();
        }

        // Преобразует заданную строку со временем в CurrentTimeZone и возвращает её, иначе возвращает пустую строку
        [Route("ConvertDate")]
        [HttpGet]
        public async Task<ActionResult<string>> ConvertDate(string date)
        {
            var result = _timeManager.ConvertDate(date);
            return result;
        }


        //-----------------------------------POST


        // Устанавливает значение CurrentTimeZone
        [HttpPost("SetTimeZone")]
        public async Task<ActionResult<bool>> SetTimeZone(string date)
        {
            var result = _timeManager.SetTimeZone(date);
            return result;
        }
    }
}
