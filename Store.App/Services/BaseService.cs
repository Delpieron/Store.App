using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Store.App.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Store.App.Services
{
    public class BaseService
    {
        protected HttpClient httpClient { get; }

        public BaseService(IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory, IOptions<StoreApi> options)
        {
            this.httpClient = httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri(options.Value.Address);

            
            var token = httpContextAccessor.HttpContext.Request.Cookies["api_token"];

            if(!string.IsNullOrEmpty(token))
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
