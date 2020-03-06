using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebSaver.Services
{
    public interface IFileService
    {
        Task SaveAsync(string text);

        Task<string> LoadAsync();
    }
}
