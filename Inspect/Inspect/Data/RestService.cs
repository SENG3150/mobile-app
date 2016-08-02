using Inspect.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Inspect.Data
{
    public class RestService : IRestService
    {
        HttpClient client;

        public RestService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://seng3150-api.wingmanwebdesign.com.au");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task Authenticate(LoginDetails loginDetails)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("/auth/authenticate", loginDetails);
            if (response.IsSuccessStatusCode)
            {
                Authentication authentication = await response.Content.ReadAsAsync<Authentication>();
                System.Diagnostics.Debug.WriteLine(authentication.Token);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authentication.Token);
            }
        }
    }
}
