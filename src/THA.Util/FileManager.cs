using THA.Domain;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using System;

namespace THA.Util
{
    public static class FileManager
    {
        public static void SaveFile(Result result, string path)
        {
            path += $@"\Files\";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            path += $@"{result.Id}.txt";

            var json = JsonConvert.SerializeObject(result);

            File.Create(path).Dispose();
            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(json);
            }
        }

        public static Result ReadFile(Guid resultId, string path)
        {
            path += @"\Files";
            string s = "";

            using (StreamReader sr = File.OpenText($"{path}/{resultId}.txt"))
                s = sr.ReadToEnd();

            return JsonConvert.DeserializeObject<Result>(s);
        }
    }
}
