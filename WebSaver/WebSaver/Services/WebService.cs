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

            Uri uri = new Uri($"http://{addres}");
            
            using (WebClient client = new WebClient())
            {
                result = await client.DownloadStringTaskAsync($"http://{addres}");
            }

            return result;
        }
    }
}
