using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{

    namespace SistemaDeRastreamentoStatus
    {
        
        public class Event
        {
            [JsonProperty("status_id")]
            public int status_id { get; set; }
            [JsonProperty("date")]
            public DateTime date { get; set; }
        }

        public class PackageInvoice
        {
            [JsonProperty("number")]
            public string number { get; set; }
            [JsonProperty("key")]
            public string key { get; set; }
            [JsonProperty("date")]
            public DateTime date { get; set; }
        }

        public class Package
        {
            [JsonProperty("package_id")]
            public int package_id { get; set; }
            [JsonProperty("package_invoice")]
            public PackageInvoice package_invoice { get; set; }
        }

        public class Rastreamento
        {
            [JsonProperty("order_id")]
            public int order_id { get; set; }
            [JsonProperty("event")]
            public Event event1 { get; set; }
            [JsonProperty("package")]
            public Package package { get; set; }
        }

        public class SistemaDeRastreamentoStatus
        {
            [JsonProperty("Rastreamento")]
            public Rastreamento Rastreamento { get; set; }
        }

        public class SistemaDeRastreamentoStatusList
        {
            public IList<Rastreamento> RastreamentoList { get; set; }
        }

    }
}