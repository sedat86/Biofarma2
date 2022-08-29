using BiofarmaDemo4.Models;
using BiofarmaDemo4.Models.Demo2;
using BiofarmaDemo4.Models.Demo3;
using BiofarmaDemo4.Models.Demo4;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BiofarmaDemo4.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        List<HES> dummyHesList = new List<HES>();
        public void fillDummyHes()
        {
            dummyHesList.Add(new HES() {HesCode="G1B5-6449-15"});
            dummyHesList.Add(new HES() {HesCode= "G5B2-3442-88"});
            dummyHesList.Add(new HES() {HesCode= "G5B2-3442-82"});
            dummyHesList.Add(new HES() {HesCode= "G5B2-3442-85"});
            dummyHesList.Add(new HES() { HesCode = "G5B2-3442-87" });
            dummyHesList.Add(new HES() { HesCode = "G5B2-3442-85" });
            dummyHesList.Add(new HES() { HesCode = "G5B2-3442-81" });
            dummyHesList.Add(new HES() { HesCode = "G5B2-3442-89" });
        }

        public string HES()
        {
            fillDummyHes(); // ??Bu bilgilerin request body den gönderilmesi istenmiş olabilir. ama olmayadabilir
            List<HES> riskyList=new List<HES>(); 
            List<HES> risklessList=new List<HES>();

            foreach (var hes in dummyHesList)
            {
                //Sonu 5 ile bitenler riskli, diğerleri risksiz olarak simüle edilmiştir.
                //Riskli olanlar ve risksiz olanlar ayrı listelere eklenmiştir
                if (hes.HesCode.EndsWith('5'))
                {
                    hes.Status = "Risky";
                    riskyList.Add(hes);
                }
                else
                {
                    hes.Status = "Riskless";
                    risklessList.Add(hes);
                }
            }

            // Soruda verilen "output" formatı ile sorunun altındaki "2 ayrı liste olsun"  kısmı çelişiyor
            //her iki durum için aşağıda kodlar mevcut.

            return JsonConvert.SerializeObject(dummyHesList); //Karışık tek liste(output formatı)

            //List<object> separated = new List<object>() { risklessList, riskyList };
            //return JsonConvert.SerializeObject(separated); //Ayrılmış iki liste
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePerson(Person person)
        {
            return this.Ok($"Post Başarılı");
        }


        public async Task<IActionResult> APICall()
        {
            List<User> userList = new List<User>();
            using (var httpClient = new HttpClient())   
            {
                using (var response = await httpClient.GetAsync("https://gorest.co.in/public/v2/users"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    userList = JsonConvert.DeserializeObject<List<User>>(apiResponse);
                }
            }
            return View(userList);
        }
    }
}
