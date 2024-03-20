using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RedResQ_WebApp.Lib.Services
{
    public class JsonService
    {
        public static TKey Deserialize<TKey>(string json)
        {
            return JsonConvert.DeserializeObject<TKey>(json)!;
        }

        public static string Serialize(object o)
        {
            return JsonConvert.SerializeObject(o);
        }
    }
}
