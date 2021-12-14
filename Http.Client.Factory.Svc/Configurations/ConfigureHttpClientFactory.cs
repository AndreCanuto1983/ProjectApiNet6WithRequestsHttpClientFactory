﻿using Http.Client.Factory.Application.Interfaces;
using Http.Client.Factory.Infra.Services;
using System.Net.Http.Headers;

namespace http_client_factory.Configurations
{
    public class ConfigureHttpClientFactory
    {            
        public static void Configurations(WebApplicationBuilder builder)
        {
            /// <summary>
            /// HttpClientFactory Typed Client Example
            /// </summary>  
            builder.Services.AddHttpClient<IHttpClientFactoryTypedClientService, HttpClientFactoryTypedClientService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44310/");

                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", builder.Configuration.GetSection("ConfigurationApi").GetSection("AccessToken").Value);                     // --> For add Authentication in header

                //client.DefaultRequestHeaders.Add("varParameter", "dataParameter");         // --> For add headers

            }).SetHandlerLifetime(TimeSpan.FromSeconds(50));                                 // --> Set lifetime in seconds


            /// <summary>
            /// //HttpClientFactory Named Clients Example
            /// </summary>  
            builder.Services.AddHttpClient("NamedClient", client =>
            {
                client.BaseAddress = new Uri("https://localhost:44310/");
                client.Timeout = new TimeSpan(0, 0, 50);                                     // --> Set Timeout (hours, minutes, seconds)
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", builder.Configuration.GetSection("ConfigurationApi").GetSection("AccessToken").Value);

            });
        }
    }
}
