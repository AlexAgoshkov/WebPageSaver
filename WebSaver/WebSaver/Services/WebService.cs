using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WebSaver.Services
{
    public class WebService : IWebService
    {
        public string GetRequest(string address)
        {
            string result = $"GET {TextWorker.GetPath(address)} HTTP/1.1\r\nHost: {TextWorker.GetDomain(address)}\r\n\r\n";

            return result;
        }

        public async Task<string> GetAsync(string address)
        {
            string result = "";

            var message = GetRequest(address);
            try
            {
                var port = 80;//19539; //80
                var serverAddr = TextWorker.GetDomain(address); //"selin.in.ua"; //"0.tcp.ngrok.io";
                var client = new TcpClient(serverAddr, port);

                var data = Encoding.ASCII.GetBytes(message);
                NetworkStream stream = client.GetStream();

                stream.Write(data, 0, data.Length);
                stream.Flush();

                var responseData = new byte[5024];
                int bytesRead = await stream.ReadAsync(responseData, 0, responseData.Length);
                var responseMessage = Encoding.ASCII.GetString(responseData, 0, bytesRead);

                result = TextWorker.GetBody(responseMessage);

                stream.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exp {ex}");
            }
            
            return result;
        }
    }
}
