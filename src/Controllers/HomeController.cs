using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Miniblog.Core.Services;
using Miniblog.Core.ViewModels;
using WebEssentials.AspNetCore.Pwa;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Miniblog.Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogService _blog;
        private readonly IOptionsSnapshot<BlogSettings> _settings;
        private readonly WebManifest _manifest;

        public HomeController(IBlogService blog, IOptionsSnapshot<BlogSettings> settings, WebManifest manifest)
        {
            _blog = blog;
            _settings = settings;
            _manifest = manifest;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View("About");
        }

        public async Task<IEnumerable<string>> GetCategories()
        {
            return await _blog.GetCategories();
        }

        private async Task<HomeVM> GetHomeVM()
        {
            return new HomeVM
            {
                Categories = await GetCategories()
            };
        }
    }
}
