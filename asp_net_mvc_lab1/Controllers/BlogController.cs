using aspNetMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace aspNetMVC.Controllers
{
    public class BlogController : Controller
    {
        private readonly ILogger<BlogController> _logger;

        private static readonly List<BlogArticleViewModel> _articles = new()
        {
            new BlogArticleViewModel { Title = "Welcome to My Blog", Description = "Intro post about the blog." },
            new BlogArticleViewModel { Title = "Learning ASP.NET MVC", Description = "Basics of ASP.NET MVC." },
            new BlogArticleViewModel { Title = "Understanding Routing", Description = "How routing works." }
        };

        public BlogController(ILogger<BlogController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(_articles);
        }
    }
}