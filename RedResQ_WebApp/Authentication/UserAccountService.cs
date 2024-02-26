using RedResQ_WebApp.Lib;
using System.Net.Http;

namespace RedResQ_WebApp.Authentication
{
    public class UserAccountService
    {

        private List<UserAccount> _users;
        HttpClient client = Consts.GetHttpClient();


        public UserAccountService()
        {
            _users = new List<UserAccount> 
            { 
                new UserAccount {UserName = "admin", Password = "admin", Role = "Administrator"},
                new UserAccount {UserName = "user", Password = "user", Role = "User"}
            };

        }

        public UserAccount? GetUserByName(string userName)
        {
            return _users.FirstOrDefault(x => x.UserName == userName);
        }

        //public async Task<UserAccount?> AuthenticateUser(string userName, string password)
        //{
        //    var httpClient = new HttpClient();
        //    var response = await httpClient.PostAsJsonAsync("https://example.com/api/authenticate", new { UserName = userName, Password = password });

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var userAccount = await response.Content.ReadFromJsonAsync<UserAccount>();
        //        return userAccount;
        //    }

        //    return null;
        //}


        public async Task<string> GetGuestTokenAsync()
        {
            try
            {
                string apiUrl = "https://api.redresq.at/guest/request";

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string token = await response.Content.ReadAsStringAsync();
                    return token;
                }
                else
                {
                    throw new HttpRequestException($"API request failed with status code {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching Guest Token: {ex.Message}");
                throw;
            }
        }

        // Neuer AuthenticateUser
        public async Task<UserAccount?> AuthenticateUser(string userName, string password)
        {
            try
            {
                var token = await GetGuestTokenAsync();


                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var requestUri = $"https://api.redresq.at/auth/login?id={Uri.EscapeDataString(userName)}&secret={Uri.EscapeDataString(password)}";

                var response = await httpClient.GetAsync(requestUri);


                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse>();
                    if (apiResponse != null)
                    {
                        return new UserAccount
                        {
                            UserName = apiResponse.username,
                            Password = password, 
                            Role = apiResponse.role.Name
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ein Fehler ist aufgetreten bei der Authentifizierung: {ex.Message}");
            }

            return null;
        }


    }
}
