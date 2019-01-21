using System;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace SettledBets
{
    public class TealiumService
    {
        private static IServiceProvider _services;
        
        public TealiumService()
        {
            _services = ConfigureServices();
        }

        public async Task<bool> PostMessage()
        {
            var movieToCreate = new MovieForCreation()
            {
                Title = "Reservoir Dogs",
                Description = "After a simple jewelry heist goes terribly wrong, the " +
     "surviving criminals begin to suspect that one of them is a police informant.",
                DirectorId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                ReleaseDate = new DateTimeOffset(new DateTime(1992, 9, 2)),
                Genre = "Crime, Drama"
            };

            var httpClientFactory = _services.GetService<IHttpClientFactory>();
            var httpClient = httpClientFactory.CreateClient("TealiumClient");

            var serializedMovieToCreate = JsonConvert.SerializeObject(movieToCreate);

            var request = new HttpRequestMessage(HttpMethod.Post, "https://postman-echo.com/post");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            request.Content = new StringContent(serializedMovieToCreate);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            //var createdMovie = JsonConvert.DeserializeObject<Movie>(content);

            return true;
        }

        #region helpers

        private static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddHttpClient("TealiumClient", client =>
            {
                client.Timeout = new TimeSpan(0, 0, 30);
                client.DefaultRequestHeaders.Clear();
            });

            return serviceCollection.BuildServiceProvider();
        }

        #endregion
    }
}
