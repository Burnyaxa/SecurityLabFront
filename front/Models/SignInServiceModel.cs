using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;
using front.Entities;
using front.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace front.Models
{
    public class SignInServiceModel
    {
        private const string SignInEndpoint = "api/v1/sign-in";
        
        public async Task<User> SignIn(Credentials credentials)
        {
            var url = string.Format(Paths.Root, SignInEndpoint);
            var client = new RestClient();
            var request = new RestRequest(url, Method.POST, DataFormat.Json);
            request.AddParameter("application/json", JsonConvert.SerializeObject(credentials), ParameterType.RequestBody);
            
            var response = await client.ExecuteAsync(request);
           
            if (!response.IsSuccessful)
            {
                if (response.StatusCode == HttpStatusCode.TooManyRequests)
                {
                    throw new AuthenticationException("Too many requests. Try again in 10 minutes.");
                }
                throw new AuthenticationException("Bad credentials.");
            }

            var userObject = JObject.Parse(response.Content)["user"];
            return userObject.ToObject<User>();
        }
    }
}