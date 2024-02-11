using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedResQ_WebApp.Lib
{
    public class PathBuilder
    {
        public string Path { get; private set; }

        public Dictionary<string, string> Parameters { get; private set; }

        public PathBuilder(string path)
        {
            Path = path;
            Parameters = new Dictionary<string, string>();
        }

        public void AddParameter(string name, string value)
        {
            Parameters.Add(name, value);
        }

        public override string ToString()
        {
            string output = Path;

            if (Parameters.Count > 0)
            {
                foreach (string key in Parameters.Keys)
                {
                    if (output.Contains('?'))
                    {
                        output += "&" + key + "=" + Parameters[key];
                    }
                    else
                    {
                        output += "?" + key + "=" + Parameters[key];
                    }
                }
            }

            return output;
        }
    }
}
