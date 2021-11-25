using System.Threading.Tasks;
using front.Entities;
using front.Helper;
using Newtonsoft.Json;
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
            request.AddJsonBody(credentials);
            var response = await client.ExecuteAsync(request);
            return JsonConvert.DeserializeObject<User>(response.Content);
        }
    }
}