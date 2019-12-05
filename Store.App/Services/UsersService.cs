using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Store.App.Helpers;
using Store.App.Models;

namespace Store.App.Services
{
    public class UsersService : BaseService,IUsersService
    {
        public UsersService(IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory, IOptions<StoreApi> options)
            : base(httpContextAccessor, httpClientFactory, options)
        {
        }
        public async Task<string> LoginAsync(UserViewModel userViewModel)
        {

            var response = await httpClient.PostAsJsonAsync("http://localhost:1588/api/v1/users/login", userViewModel);

            if(response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return null;
            }

            var authSuccess = await response.Content.ReadAsAsync<AuthSuccess>();
            return authSuccess.Token;
        }
    }
}
