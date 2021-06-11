using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebClient.Models
{
    public abstract class BaseService
    {
        static protected Uri uri = new Uri("https://localhost:44395/api/");
        protected static List<T> Gets<T>(string requestUri)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = uri;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = client.GetAsync(requestUri).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<List<T>>().Result;
                }
                return null;
            }
        }
        protected static T Get<T>(string requestUri)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = uri;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = client.GetAsync(requestUri).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<T>().Result;
                }
                return default;
            }
        }
        protected static int Post<T>(string requestUri, T obj)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = uri;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = client.PostAsync<T>(requestUri, obj, new JsonMediaTypeFormatter()).Result;
                if (responseMessage.IsSuccessStatusCode)//success > 0
                {
                    return responseMessage.Content.ReadAsAsync<int>().Result;
                }
                return 0;
            }
        }
        protected static int Delete(string requestUri)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = uri;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = client.DeleteAsync(requestUri).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<int>().Result;
                }
                return 0;
            }
        }
        protected static int Put<T>(string requestUri, T obj)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = uri;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = client.PutAsync<T>(requestUri, obj, new JsonMediaTypeFormatter()).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage.Content.ReadAsAsync<int>().Result;
                }
                return 0;
            }
        }
        protected static T SignIn<T>(string requestUri)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = uri;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = client.GetAsync(requestUri).Result;
                var jsonString = responseMessage.Content.ReadAsStringAsync().Result;
                //var jsonString = responseMessage.Content.ReadAsAsync<List<T>>().Result;
                //T data = (T)JsonConvert.DeserializeObject("jsonString", typeof(T));
                var Datas = JsonConvert.DeserializeObject<T>(jsonString.ToString());

                //var data = Datas[0];
                if (responseMessage.IsSuccessStatusCode)
                {
                    return Datas;
                    //return data;
                    //return responseMessage.Content.ReadAsAsync<T>().Result;
                }
                return default;

            }
        }
    }
}
