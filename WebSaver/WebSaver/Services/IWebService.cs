using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebSaver.Services
{
    public interface IWebService
    {
        Task<string> GetAsync(string addres);
    }
}
