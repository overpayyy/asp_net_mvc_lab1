using aspNetMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace aspNetMVC.Controllers
{
    public class BlogController : Controller
    {
        private readonly ILogger<BlogController> _logger;

        private static readonly List<BlogArticleViewModel> _articles = new()
        {
            new BlogArticleViewModel {
                Id = "welcome-to-my-blog",
                Title = "Welcome to My Blog",
                Description = "Intro post about the blog.",
                Content = "This is the <b>content</b> of the welcome post. Welcome to our journey!"
            },
            new BlogArticleViewModel {
                Id = "learning-aspnet-mvc",
                Title = "Learning ASP.NET MVC",
                Description = "Basics of ASP.NET MVC.",
                Content = "Here we learn about <i>Controllers</i>, <i>Models</i>, and <i>Views</i>. It's really cool."
            },
            new BlogArticleViewModel {
                Id = "understanding-routing",
                Title = "Understanding Routing",
                Description = "How routing works.",
                Content = "Routing maps URL paths to <u>Controller Actions</u>."
            }
        };

        public BlogController(ILogger<BlogController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(_articles);
        }

        public IActionResult Article(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return NotFound();

            var post = _articles.FirstOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (post == null) return NotFound();

            return View(post);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateBlogArticleModel());
        }

        [HttpPost]
        public IActionResult Create(CreateBlogArticleModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Id)) return Content("Provide an Id.");

            var stored = new BlogArticleViewModel
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Content = model.Content
            };

            _articles.Add(stored);

            return RedirectToAction(nameof(Article), new { id = stored.Id });
        }
    }
}