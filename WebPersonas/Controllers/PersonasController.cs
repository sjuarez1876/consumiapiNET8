using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Policy;
using WebPersonas.Models;

namespace WebPersonas.Controllers
{
    public class PersonasController : Controller
    {
        
        HttpClient client = new HttpClient();
        string urlConsulta = "http://localhost:5214/api/Personas/ConsultaPersonas";
        string urlAgrega = "http://localhost:5214/api/Personas/AgregaPersonas";
        public async Task <IActionResult> Index()
        {
            List<Personas> lspersonas = new List<Personas>();
            lspersonas   = JsonConvert.DeserializeObject<List<Personas>>(await client.GetStringAsync(urlConsulta)).ToList();
            return View(lspersonas);
        }

        // GET: PersonasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonasController/Create
        
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(Personas collection)
        {
            try
            {
               // ResponseGeneric<Personas> objResponse = new ResponseGeneric<Personas>();


                var resp = await client.PostAsJsonAsync<Personas>(urlAgrega, collection);
                if (resp.IsSuccessStatusCode) {
                    var respContent = resp.Content.ReadAsStringAsync().Result;

                }

                //HttpResponseMessage response = client.PostAsJsonAsync("http://localhost:5214/api/Personas/AgregaPersonas", collection).Result;
                //if (response.IsSuccessStatusCode)
                //{
                //    var employee = response.Content.ReadAsStringAsync();
                //    //HOW DO I CONVERT THE OUTPUT INTO LIST<EMPLOYEE>?
                //    Console.Write("---DONE---");
                //}

                //var response = new HttpClient().PostAsJsonAsync(urlAgrega, collection).Result;


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
