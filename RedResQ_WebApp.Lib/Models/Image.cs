using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedResQ_WebApp.Lib.Models
{
    public class Image
    {
        #region Constructor

        public Image(long id, string description, byte[] bytes)
        {
            Id = id;
            Description = description;
            Bytes = bytes;
        }

        #endregion

        #region Properties

        public long Id { get; private set; }

        public string Description { get; private set; }

        public byte[] Bytes { get; private set; }

        #endregion
    }

}
