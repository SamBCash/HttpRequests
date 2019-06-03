using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

public class HttpGet : MonoBehaviour
{
    // figure out utillity...wise....
    //
    // 

    // Start is called before the first frame update
    async void Start() // Tony added async
    {
        string url = "http://game.orodev.com/api/GameTables.aspx";
        try
        {
            string responseBody = await HttpGetAsync(url);
            if (responseBody != null)
            {
                DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(responseBody);
                DataTable dataTable = dataSet.Tables["Table1"];

                foreach (DataRow row in dataTable.Rows)
                {
                    Debug.Log(row["Id"] + "--" + row["Name"] + "<--");
                }
            }
        }
        catch (HttpRequestException ex)
        {
            Debug.Log("Hello Unity This is an error! = " + ex);
        }
    }
    
    protected async Task<string> HttpGetAsync(string url) // Make Class utility...
    {
        HttpServiceAsync client = new HttpServiceAsync();
        Task<string> responseBodyTask = client.GetStringAsync(url); 
        string responseBody = await responseBodyTask;

        return responseBody;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public class HttpServiceAsync : HttpClient //TODO: move to utl
    {
        static readonly HttpClient httpClient; //HACK singleton. I hope

        static HttpServiceAsync() // Class initiation
        {
            httpClient = new HttpClient();
        }
    }
}