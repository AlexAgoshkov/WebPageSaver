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
        public async Task<string> GetAsync(string addres)
        {
            string result = "";

            var message = $"GET / HTTP/1.0\nHost: {addres}\r\n\r\n";
            try
            {
                var port = 80;//19539; //80
                var serverAddr = addres; //"selin.in.ua"; //"0.tcp.ngrok.io";
                var client = new TcpClient(serverAddr, port);

                var data = Encoding.ASCII.GetBytes(message);
                NetworkStream stream = client.GetStream();

                stream.Write(data, 0, data.Length);
                stream.Flush();

                var responseData = new byte[1024];
                int bytesRead = await stream.ReadAsync(responseData, 0, responseData.Length);
                var responseMessage = Encoding.ASCII.GetString(responseData, 0, bytesRead);

                string[] words = responseMessage.Split(new char[] { '\n' });

                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i].StartsWith("<!Doctype") || words[i].StartsWith("<!DOCTYPE"))
                    {
                        for (int j = i; j < words.Length; j++)
                        {
                            result += words[j];
                        }
                        break;
                    }
                }

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
