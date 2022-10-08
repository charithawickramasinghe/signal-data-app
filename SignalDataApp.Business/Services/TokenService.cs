using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SignalDataApp.Business.Services
{
    public class TokenService : ITokenService
    {
        public async Task<string> GetToken()
        {
            //get an access token and save in a session.
            using (var client = new HttpClient())
            {
                var response = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                    Address = "https://i4test.azurewebsites.net/connect/token",

                    ClientId = "recruit",
                    ClientSecret = "ey9nf7E7E6ErAkdD7nWG"
                });

                return response.AccessToken.ToString();
            }
        }
    }
}
