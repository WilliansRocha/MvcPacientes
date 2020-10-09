using Newtonsoft.Json;

namespace Mvc.Models
{
    public class Pacientes
    {
        [JsonProperty("id")]
         public long id {get; set;}
         [JsonProperty("idPessoa")]
        public int idPessoa {get; set;}
        [JsonProperty("data_entrada")]
        public string data_entrada { get; set; }
        [JsonProperty("comorbidade")]
        public string comorbidade {get; set;}
        [JsonProperty("grau")]
        public int grau{get;set;}

        public Pacientes(long id, int idPessoa, string data_entrada, string comorbidade, int grau){
        this .id = id;
        this.idPessoa = idPessoa;
        this.data_entrada = data_entrada;
        this.comorbidade = comorbidade;
        this.grau = grau;
        }

    }
}