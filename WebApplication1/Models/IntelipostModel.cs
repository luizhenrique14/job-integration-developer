using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using WebApplication1.Models.SistemaDeRastreamentoStatus;
using WebApplication1.Models.SistemaDeVendasStatus;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;

namespace WebApplication1.Models
{
    namespace IntelipostModel
    {
        public class IntelipostModel
        {
            public HttpWebResponse RespostaSistemaDeVendas;
            public static String JsonConverte(Rastreamento json)
            {
                
                var orderid = json.order_id.ToString();
                var statusID = json.event1.status_id;
                var data = json.event1.date;
                var package_id = json.package.package_id;
                var package_number = json.package.package_invoice.number;
                var package_key = json.package.package_invoice.key;
                var package_date = json.package.package_invoice.date;


                Vendas sisVendas = new Vendas();

                if (statusID == 1)
                {
                    sisVendas.status = "in_transit";
                }
                else if(statusID == 2)
                {
                    sisVendas.status = "to_be_delivered";
                }
                else if (statusID == 3)
                {
                    sisVendas.status = "delivered";
                }

                sisVendas.orderId = orderid;
                sisVendas.date = data.ToString();

                //Create a stream to serialize the object to.  
                MemoryStream ms = new MemoryStream();

                // Serializer the User object to the stream.  
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Vendas));
                ser.WriteObject(ms, sisVendas);
                byte[] jsonSerializer = ms.ToArray();
                ms.Close();
                var Return = Encoding.UTF8.GetString(jsonSerializer, 0, jsonSerializer.Length);

                var teste = HttpClient(Return, "http://localhost:8080/Vendas");

                return Return;

            }

            public static HttpWebResponse HttpClient(string JSon, String URI)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URI);
                request.Method = "POST";

                System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                Byte[] byteArray = encoding.GetBytes(JSon);

                request.ContentLength = byteArray.Length;
                request.ContentType = @"Vendas";

                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }
                long length = 0;                
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                
                return response;
              
            }
        }
    }
}
