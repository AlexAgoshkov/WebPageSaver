using System;
using System.Collections.Generic;
using System.Text;

namespace WebSaver.Services
{
    class TextWorker
    {
        public static string GetBody(string text)
        {
            string result = "";

            string[] words = text.Split(new char[] { '\n' });

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length == 1)
                {
                    for (int j = i; j < words.Length; j++)
                    {
                        result += "\n" + words[j];
                    }
                    break;
                }
            }

            return result.Trim();
        }

        public static string GetPath(string text)
        {
            string result = "";

            if (IsHttp(text))
            {
                string[] words = text.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                if (words.Length == 2)
                {
                    result = "/";
                }
                else
                {
                    for (int i = 2; i < words.Length; i++)
                    {
                        result += "/" + words[i];
                    }
                }
            }

            return result;
        }

        public static string GetDomain(string text)
        {
            string result = "";

            if (IsHttp(text))
            {
                string[] words = text.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                result = words[1];
            }

            return result;
        }

        private static bool IsHttp(string text)
        {
            bool result = false;

            if (text.StartsWith("http"))
            {
                result = true;
            }

            return result;
        }

        public static string GetFormat(string text)
        {
            string result = "";

            string[] words = text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            result = words[words.Length - 1];

            return result;
        }
    }
}
