using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using UnityEngine;
using static Http_2;

public class HttpTest_2 : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
        string url = "http://game.orodev.com/api/GameTables.aspx";
        HttpServiceAsync_2 client = new HttpServiceAsync_2();
        try
        {
            string responseBody = await client.GetStringAsync(url);
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
