using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    namespace SistemaDeVendasStatus
    {
        public class Vendas
        {
            [JsonProperty("orderId")]
            public string orderId { get; set; }

            [JsonProperty("status")]
            public string status { get; set; }

            [JsonProperty("date")]
            public string date { get; set; }
        }

        public class SistemaDeVendasStatus
        {
            [JsonProperty("Vendas")]
            public Vendas Vendas { get; set; }
        }

        public class SistemaDeVendasStatusInstanciar
        {
            public Vendas Vendas { get; set; }
        }

        public class SistemaDeVendasStatusList
        {
            public IList<Vendas> VendasList { get; set; }
        }
    }

}