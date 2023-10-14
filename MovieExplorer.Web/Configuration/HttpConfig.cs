using System.Net.Http.Headers;

namespace MovieExplorer.Web.Configuration
{
    public static class HttpConfig
    {
        public static void AddHttpConfig(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddHttpClient("MOVIE", httpClient =>
            {
                httpClient.BaseAddress = new Uri(builder.Configuration.GetSection("API").GetValue<string>("Endpoint"));
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });
        }
    }
}
