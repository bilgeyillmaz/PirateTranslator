using CaseAFS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CaseAFS.Controllers
{
    [Authorize(Roles="Member, Admin")]
    public class TranslationController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            Translate translate = new Translate();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://api.funtranslations.com/translate/pirate?text=hi"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    translate = JsonConvert.DeserializeObject<Translate>(apiResponse);
                }
            }
            return View(translate);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string Text)
        {
            Translate translate = new Translate();
            using (var httpClient = new HttpClient())
            {
                string apiurl = "http://api.funtranslations.com/translate/pirate?text=" + Text;
                using (var response = await httpClient.GetAsync(apiurl))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    translate = JsonConvert.DeserializeObject<Translate>(apiResponse);
                }
            }
            return View(translate);
        }
    }
}
