using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Mvc.Models;
using Newtonsoft.Json;

namespace Mvc.Repositorio
{
    public class PacientesRepositorio
    {
        HttpClient cliente = new HttpClient();
        public PacientesRepositorio(){
            cliente.BaseAddress = new Uri("http://localhost:5001/api/pacientesdotnet");
            cliente.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("aplication/json"));
        }
        public async Task<List<Pacientes>> GetPacientesAsync(){
            HttpResponseMessage response = await cliente.GetAsync("api/pacientes");
            if(response.IsSuccessStatusCode){
                var dados = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Pacientes>>(dados);
            }
            return new List<Pacientes>();
        }
    }
}