using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Store.App.Helpers;
using Store.App.Models;
using Store.App.StoreApiCotracts.Responses;

namespace Store.App.Services
{
    public class CategoriesService :  BaseService , ICategoriesService
    {

        public CategoriesService(IHttpContextAccessor httpContextAccessor, IHttpClientFactory httpClientFactory, IOptions<StoreApi> options)
            :base(httpContextAccessor, httpClientFactory, options)
        {
        }
        public async Task<ICollection<CategoryViewModel>> GetAllAsync()
        {
            var response = await httpClient.GetAsync("/api/v1/categories");
            var categories = await response.Content.ReadAsAsync<PagedResponse<CategoriesResponse>>();
            var categoriesViewModel = categories.Data.Select(x => new CategoryViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return categoriesViewModel;
        }
    }
}
