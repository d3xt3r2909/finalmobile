using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ESBX_MyPLC.Util
{
    public class WebAPIHelper
    {
        public HttpClient Client { get; set; }
        public string Route { get; set; }

        public WebAPIHelper(string uri, string route)
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(uri);
            Route = route;
        }

        public HttpResponseMessage GetResponse()
        {
            // Povratni tip GetAsync metode je onaj sto se prikazuje
            // sluzi kako bi asihrono izvrsavali funkciju, medjutim ako napisemo
            // kao dole sto smo napisali tada se ova metoda izvrsava sihrono odnosno
            // ceka se na izvrsavanje coda
            return Client.GetAsync(Route).Result;
        }

        public HttpResponseMessage GetResponse(int id)
        {

            return Client.GetAsync(Route + "/" + id).Result;

        }

        public HttpResponseMessage GetCustomRouteResponse(string route, string parameters = "")
        {
            return Client.GetAsync(route + parameters).Result;
        }

        public HttpResponseMessage DeleteCustomRouteResponse(string route, string parameters = "")
        {
            return Client.DeleteAsync(route + parameters).Result;
        }

        //public HttpResponseMessage PutCustomRouteResponse(string route, object mObject, string parameters = "")
        //{
        //    return Client.PutAsJsonAsync(route + parameters, mObject).Result;
        //}
        public HttpResponseMessage GetResponse(string parametar = "")
        {

            return Client.GetAsync(Route + "/" + parametar).Result;

        }

        public HttpResponseMessage GetActionResponse(string action, string parameter = "")
        {
            return Client.GetAsync(Route + "/" + action + "/" + parameter).Result;
        }

        //PROVJERI
        public HttpResponseMessage GetActionResponse(string action, string DatumOd, string DatumDo)
        {
            return Client.GetAsync(Route + "/" + action + "/" + DatumOd + "/" + DatumDo).Result;
        }

        public HttpResponseMessage PostResponse(object account)
        {
            var jsonObject = new StringContent(JsonConvert.SerializeObject(account), Encoding.UTF8, "application/json");
            return Client.PostAsync(Route, jsonObject).Result;
        }

     

        public HttpResponseMessage PostCustomRouteResponse(string route, object mObject)
        {
            var jsonObject = new StringContent(JsonConvert.SerializeObject(mObject), Encoding.UTF8, "application/json");
            return Client.PostAsync(route, jsonObject).Result;
        }

        //public HttpResponseMessage PutResponse(int id, object existingObject)
        //{
        //    return Client.PutAsJsonAsync(Route + "/" + id, existingObject).Result;
        //}
    }
}
