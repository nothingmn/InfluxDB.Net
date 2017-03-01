using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using InfluxDB.Core.Enums;
using InfluxDB.Core.Infrastructure.Validation;

namespace InfluxDB.Core.Infrastructure.Configuration
{
    public class InfluxDbClientConfiguration
    {
        public Uri EndpointBaseUri { get; internal set; }

        public string Username { get; private set; }

        public string Password { get; private set; }

        public InfluxVersion InfluxVersion { get; private set; }

        public TimeSpan? RequestTimeout { get; private set; }

        public InfluxDbClientConfiguration(Uri endpoint, string username, string password, InfluxVersion influxVersion, TimeSpan? requestTimeout)
        {
            Validate.NotNull(endpoint, "Endpoint may not be null or empty.");
            Validate.NotNullOrEmpty(password, "Password may not be null or empty.");
            Validate.NotNullOrEmpty(username, "Username may not be null or empty.");
            Username = username;
            Password = password;
            InfluxVersion = influxVersion;
            EndpointBaseUri = SanitizeEndpoint(endpoint, false);
            RequestTimeout = requestTimeout;

            
            handler.AllowAutoRedirect = true;

        }


        private Uri SanitizeEndpoint(Uri endpoint, bool isTls)
        {
            var builder = new UriBuilder(endpoint);

            if (isTls)
            {
                builder.Scheme = "https";
            }
            else if (builder.Scheme.Equals("tcp", StringComparison.CurrentCultureIgnoreCase))
            //InvariantCultureIgnoreCase, not supported in PCL
            {
                builder.Scheme = "http";
            }

            return builder.Uri;
        }
        private readonly HttpClientHandler handler = new HttpClientHandler();

        public HttpClient BuildHttpClient()
        {
            
            var client = new HttpClient(handler);
            client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/jsoin"));

            client.Timeout = TimeSpan.FromMinutes(1);
            return client;
        }
    }
}