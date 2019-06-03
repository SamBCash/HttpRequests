using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using static Http;

public class HttpTest : MonoBehaviour
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
            string responseBody = await Http.HttpServiceAsync.HttpGetStringAsync(url);
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

