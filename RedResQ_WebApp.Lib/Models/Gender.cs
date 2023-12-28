﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedResQ_WebApp.Lib.Models
{
	public class Gender
	{
		#region Constructor

		public Gender(long id, string name)
		{
			Id = id;
			Name = name;
		}

		#endregion

		#region Properties

		public long Id { get; private set; }

		public string Name { get; private set; }

		#endregion

		
	}
}
