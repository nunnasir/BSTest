using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using BSTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace BSTest.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            var model = Startup.AutofacContainer.Resolve<PostModel>();
            return View(model);
        }

        public IActionResult GetPosts()
        {
            var tableModel = new DataTableAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<PostModel>();
            var data = model.GetPosts(tableModel);
            return Json(data);
        }
    }
}
