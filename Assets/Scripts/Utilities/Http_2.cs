using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using UnityEngine;

public class Http_2 : MonoBehaviour
{
    public class HttpServiceAsync_2 : HttpClient
    {
        static readonly HttpClient httpClient_2; //HACK singleton. I hope

        static HttpServiceAsync_2() // Class initiation
        {
            httpClient_2 = new HttpClient();
        }
    }
}
