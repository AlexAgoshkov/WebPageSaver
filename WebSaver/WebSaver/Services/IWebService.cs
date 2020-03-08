using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebSaver.Services
{
    public interface IWebService
    {
        string GetRequest(string address);
        Task<string> GetAsync(string addres);
    }
}
