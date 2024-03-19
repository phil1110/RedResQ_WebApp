namespace RedResQ_WebApp.Authentication
{
    public class UserAccountService
    {
        private List<UserAccount> _users;

        public UserAccountService()
        {
            _users = new List<UserAccount>
            {
                new UserAccount {UserName = "admin", Password = "admin", Role = "Administrator"},
                new UserAccount {UserName = "user", Password = "user", Role = "user"},
            };
        }

        public UserAccount? GetUserByName(string userName)
        {
            return _users.FirstOrDefault(x => x.UserName == userName);
        }
    }
}
