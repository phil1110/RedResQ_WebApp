using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace RedResQ_WebApp.Lib.Models
{
	public class User
	{
		#region Constructor

		public User(long id, string username, string firstName, string lastName, string email, DateTime birthdate,
			Gender gender, Language language, Location location, Role role)
		{
			Id = id;
			Username = username;
			FirstName = firstName;
			LastName = lastName;
			Email = email;
			Birthdate = birthdate;
			Gender = gender;
			Language = language;
			Location = location;
			Role = role;
		}

		#endregion

		#region Properties

		public long Id { get; set; }

		public string Username { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Email { get; set; }

		public DateTime Birthdate { get; set; }

		public Gender Gender { get; set; }

		public Language Language { get; set; }

		public Location Location { get; set; }

		public Role Role { get; set; }

		#endregion

	

	}
}
