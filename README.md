# HttpRequests
Best Practice implimentation...
This is my first GitHub Project...
Issue is instantiate singlton HttpClient

https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=netframework-4.8 

ttpClient is intended to be instantiated once and re-used throughout the life of an application. Instantiating an HttpClient class for every request will exhaust the number of sockets available under heavy loads. This will result in SocketException errors. Below is an example using HttpClient correctly.

C#

Copy
public class GoodController : ApiController
{
    // OK
    private static readonly HttpClient HttpClient;

    static GoodController()
    {
        HttpClient = new HttpClient();
    }
}
