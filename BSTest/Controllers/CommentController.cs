using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using BSTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace BSTest.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            var model = Startup.AutofacContainer.Resolve<CommentModel>();
            return View(model);
        }

        public IActionResult GetComments()
        {
            var tableModel = new DataTableAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<CommentModel>();
            var data = model.GetComments(tableModel);
            return Json(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LikeComment(int id)
        {
            if (ModelState.IsValid)
            {
                var model = new CommentModel();
                model.LikeComment(id);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DisLikeComment(int id)
        {
            if (ModelState.IsValid)
            {
                var model = new CommentModel();
                model.DisLikeComment(id);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
