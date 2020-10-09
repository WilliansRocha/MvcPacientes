using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mvc.Models;
using Mvc.Repositorio;
using Newtonsoft.Json;
using static System.Console;

namespace Mvc.Controllers
{
    public class PacientesController : Controller
    {
        private readonly HttpClient client;
        private readonly ILogger<PacientesController> logger;

        public PacientesController(ILogger<PacientesController> logger){
            this.logger = logger;
            client = new HttpClient{
                BaseAddress = new Uri("http://localhost:5000/api/")
            };
        }
        public IActionResult Index(){
            var responseString = GetPacientes().Result;
            var lista = JsonConvert.DeserializeObject<IEnumerable<Pacientes>>(responseString);
            return View(lista);
        }
        public IActionResult Editar(){
            return View();
        }
         public IActionResult Excluir(){
            return View();
        }
        async Task<string> GetPacientes(){
            HttpResponseMessage response = await client.GetAsync("pacientes");
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
        

         [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}