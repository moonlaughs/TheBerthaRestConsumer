using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TheBerthaUDPBroadcastReceiver
{
    class Program
    {
        private const int Port = 7000;
        static readonly HttpClient Client = new HttpClient();
        private static string url = "https://thebertharestconsumer20181031102055.azurewebsites.net/api/Temperature";

        static TemperatureClass TempObj = new TemperatureClass();

        static void Main()
        {
            using (UdpClient socket = new UdpClient(new IPEndPoint(IPAddress.Any, Port)))
            {
                IPEndPoint remoteEndPoint = new IPEndPoint(0, 0);

                Client.BaseAddress = new Uri(url);
                Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                while (true)
                {
                    Console.WriteLine("Waiting for broadcast {0}", socket.Client.LocalEndPoint);
                    byte[] datagramReceived = socket.Receive(ref remoteEndPoint);

                    string message = Encoding.ASCII.GetString(datagramReceived, 0, datagramReceived.Length);
                    Console.WriteLine("Receives {0} bytes from {1} port {2} message {3}", datagramReceived.Length,
                        remoteEndPoint.Address, remoteEndPoint.Port, message);
                    PostResponse(message).GetAwaiter();
                }
            }
        }
        
        private static async Task<TemperatureClass> PostResponse(string response)
        {
            TempObj.Temp = response;
            DateTime date = DateTime.Now;
            TempObj.DT = date;

            var jsonString = JsonConvert.SerializeObject(TempObj);
            StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMsg = await Client.PostAsync(url, content);

            if (responseMsg.StatusCode == HttpStatusCode.Conflict)
            {
                throw new Exception();
            }
            responseMsg.EnsureSuccessStatusCode();

            return TempObj;
        }
    }
}
