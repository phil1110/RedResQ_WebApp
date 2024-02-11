using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RedResQ_WebApp.Lib.Models
{
    public class Country
    {
        #region Constructor

        public Country(long id, string countryName)
        {
            Id = id;
            CountryName = countryName;
        }

        #endregion

        #region Properties

        [JsonRequired]
        public long Id { get; set; }

        [JsonRequired]
        public string CountryName { get; set; }

        #endregion
    }

}
