using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LunarCalendar.Models.Home;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace LunarCalendar.Controllers
{
    [Route("/")]
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IConfiguration Configuration { get; }

        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [Route("")]
        [Route("Index")]
        [HttpGet]
        public ActionResult Index()
        {
            var response = new IndexModel()
            {
                ApplicationName = Program.Name,
                ApplicationAuthor = Program.Author,
                ApplicationDescription = Program.Name + " Public API.",
                ApplicationVersion = Program.Version,
                ApplicationOwner = Configuration["General:Owner"],
                ApplicationOwnerContact = Configuration["General:Contact"]
            };

            return new JsonResult(response);
        }
    }
}