using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.App.Models;
using Store.App.Services;

namespace Store.App.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;
        private readonly ICategoriesService categoriesService;

        public ProductsController(IProductsService productsService, ICategoriesService categoriesService)
        {
            this.productsService = productsService;
            this.categoriesService = categoriesService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await productsService.GetAllAsync();
            return View(products);
        }
        public async Task<IActionResult> Create()
        {
            var createProductModelView = new CreateViewModel();
            var categories = await categoriesService.GetAllAsync();
            createProductModelView.Categories = new SelectList(
                categories, 
                nameof(CategoryViewModel.Id),
                nameof(CategoryViewModel.Name)
                );

            return View(createProductModelView);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateViewModel createViewModel)
        {
            var success = await productsService.AddAsync(createViewModel);
            if (success)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(createViewModel);
        }
    }
}