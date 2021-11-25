using System.Net;
using System.Threading.Tasks;
using front.Entities;
using front.Helper;
using Newtonsoft.Json;
using RestSharp;

namespace front.Models
{
    public class RegistrationServiceModel
    {
        private const string RegistrationEndpoint = "api/v1/sign-up";

        public async Task<string> Register(User user)
        {
            var url = string.Format(Paths.Root, RegistrationEndpoint);
            var client = new RestClient();
            var request = new RestRequest(url, Method.POST, DataFormat.Json);
            request.AddJsonBody(user);
            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                return "Successful registration";
            }
            if(response.StatusCode == HttpStatusCode.TooManyRequests)
            {
                return "Too many requests. Try again in 10 minutes";
            }

            return JsonConvert.DeserializeObject<RegistrationErrorResponse>(response.Content).Description;
        }
    }
}