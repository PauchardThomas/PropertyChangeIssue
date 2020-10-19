using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Basket.Helper
{
    public class FileReader<T> : IReader<T>
    {
        public Assembly Assembly { get; set; }

        public FileReader()
        {
            Assembly = typeof(FileReader<T>).GetTypeInfo().Assembly;
        }

        public T Read(string jsonName, string pathFromAssembly = default)
        {
            T obj;
            try
            {
                Stream stream = Assembly.GetManifestResourceStream($"{Assembly.GetName().Name}.{pathFromAssembly}{jsonName}");
                using (var reader = new StreamReader(stream))
                {
                    var jsonString = reader.ReadToEnd();
                    obj = JsonConvert.DeserializeObject<T>(jsonString);
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return obj;
        }
    }
}
