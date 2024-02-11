using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RedResQ_WebApp.Lib.Models
{
    public class Language
    {
        #region Constructor

        public Language(long id, string name)
        {
            Id = id;
            Name = name;
        }

        #endregion

        #region Properties

        [JsonRequired]
        public long Id { get; set; }

        [JsonRequired]
        public string Name { get; set; }

        #endregion
    }
}
