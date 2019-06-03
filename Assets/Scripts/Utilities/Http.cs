using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

public class Http : MonoBehaviour
{
    public class HttpServiceAsync : HttpClient
    {
        static readonly HttpClient httpClient; //HACK singleton. I hope

        static HttpServiceAsync() // Class initiation
        {
            httpClient = new HttpClient();
        }
        public static async Task<string> HttpGetStringAsync(string url) 
        {
            HttpServiceAsync client = new HttpServiceAsync();
            Task<string> responseBodyTask = client.GetStringAsync(url);
            string responseBody = await responseBodyTask;

            return responseBody;
        }
        public static async Task<HttpResponseMessage> HttpPostAsync(string url, HttpContent content)
        {
            HttpServiceAsync client = new HttpServiceAsync();
            Task<HttpResponseMessage> responseBodyTask = client.PostAsync(url, content);



            HttpResponseMessage responseBody = await responseBodyTask;

            return responseBody;
        }
    }
}
