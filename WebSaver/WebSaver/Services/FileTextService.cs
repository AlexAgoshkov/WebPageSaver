using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace WebSaver.Services
{
    public class FileTextService : IFileService
    {
        private const string Path = "output.html";

        public async Task<string> LoadAsync()
        {
            string result = null;
            using (var sr = new StreamReader(Path))
            {
                result = await sr.ReadToEndAsync();
            }
            return result;
        }

        public async Task SaveAsync(string text)
        {
            using (var sw = new StreamWriter(Path))
            {
                await sw.WriteAsync(text);
            }
        }

    }
}
