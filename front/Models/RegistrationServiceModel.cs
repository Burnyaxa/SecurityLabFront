using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using front.Entities;
using front.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace front.Models
{
    public class RegistrationServiceModel
    {
        private const string RegistrationEndpoint = "api/v1/sign-up";

        public async Task<string> Register(RegistrationForm user)
        {
            var url = string.Format(Paths.Root, RegistrationEndpoint);
            var client = new RestClient();
            var request = new RestRequest(url, Method.POST, DataFormat.Json);
            request.AddParameter("application/json", JsonConvert.SerializeObject(user), ParameterType.RequestBody);
            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                return "Successful registration";
            }
            if(response.StatusCode == HttpStatusCode.TooManyRequests)
            {
                return "Too many requests. Try again in 10 minutes";
            }

            if (response.StatusCode == HttpStatusCode.UnprocessableEntity)
            {
                var errors = JObject.Parse(response.Content)["error"].Children();
                var result = errors.Aggregate("", (x, y) => x + Environment.NewLine + y);
                return result;
            }

            if (response.StatusCode == HttpStatusCode.Conflict)
            {
                return "User already exists";
            }

            return "Oops server tupit sorry XD";
        }
    }
}