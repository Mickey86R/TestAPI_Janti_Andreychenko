using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Data;
using System.Globalization;

namespace TestAPI_Janti_Andreychenko.Controllers
{
    [Route("/TimeManager/")]
    [ApiController]
    public class HomeController : Controller
    {
        public HomeController() { }

        [Route("/GetTime")]
        [HttpGet]
        public async Task<ActionResult<string>> GetTime()
        {
            return await TimeManager.GetTime();
        }

        [Route("/ConvertDate")]
        [HttpGet]
        public async Task<ActionResult<string>> ConvertDate(string date)
        {
            var str = "";
            return str;
        }


        [HttpPost("/SetTimeZone")]
        public async Task<ActionResult<bool>> SetTimeZone(string date)
        {
            var result = await TimeManager.SetTimeZone(date);
            return result;
        }


    }
}
