using RedResQ_WebApp.Lib.Models;

namespace RedResQ_WebApp.Authentication
{
    public class ApiResponse
    {
        public int id { get; set; }
        public string username { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public DateTime birthdate { get; set; }
        public Gender gender { get; set; }
        public Language language { get; set; }
        public Location location { get; set; }
        public Role role { get; set; }
    }
}
