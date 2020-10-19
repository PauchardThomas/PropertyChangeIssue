using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Basket
{
    public class BasketReader
    {
        Assembly Assembly { get; set; }
        public BasketReader()
        {
            Assembly = typeof(BasketReader).GetTypeInfo().Assembly;
        }

        public Basket Read(string jsonName)
        {
            Basket basket = null;
            try
            {
                Stream stream = Assembly.GetManifestResourceStream($"{Assembly.GetName().Name}.json.{jsonName}");
                using (var reader = new StreamReader(stream))
                {
                    var jsonString = reader.ReadToEnd();
                    basket = JsonConvert.DeserializeObject<Basket>(jsonString);
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return basket;
        }

    }
}
