using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using WebApplication1.Models.SistemaDeRastreamentoStatus;
using WebApplication1.Models.IntelipostModel;

namespace WebApplication1.Controllers
{
    public class IntelipostController : ApiController
    {
        // GET: api/Intelipost
        [HttpGet]
        public string Get(HttpRequestMessage value)
        {
            var content = value.Content.ReadAsStringAsync().Result;
            String RetornoJSon = JsonConvert.DeserializeObject(content).ToString();

            var json = JsonConvert.DeserializeObject<Rastreamento>(RetornoJSon);

            var Retorno = IntelipostModel.JsonConverte(json);

            return Retorno;
        }

        // GET: api/Intelipost/QUALQUER NUMERO
        public String  Get(String Mensagem)
        {            
            //string Retorno = Model.ConverteJson(Mensagem);
            return Mensagem;
        }


        // POST: api/Intelipost
        [HttpPost]
        public string Post(HttpRequestMessage value)
        {
            
            var content = value.Content.ReadAsStringAsync().Result;
            var RetornoJSon = JsonConvert.DeserializeObject(content).ToString();

            var json = JsonConvert.DeserializeObject<Rastreamento>(RetornoJSon);

            var orderid = json.order_id;
            var statusID = json.event1.status_id;
            var data = json.event1.date;
            var package_id = json.package.package_id;
            var package_number = json.package.package_invoice.number;
            var package_key =  json.package.package_invoice.key;
            var package_date = json.package.package_invoice.date;


            return orderid +" " + data + " " + statusID;
        }

        // PUT: api/Intelipost/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Intelipost/5
        public void Delete(int id)
        {
        }
    }
}
