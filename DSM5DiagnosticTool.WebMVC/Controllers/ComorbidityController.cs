using DSM5.Models;
using DSM5.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSM5DiagnosticTool.WebMVC.Controllers
{
    public class ComorbidityController : Controller
    {
        // GET: Comorbidity
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ComorbidityService(userId);
            var model = service.GetComorbidty();
            return View(model);
        }

        // GET:
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ComorbidityCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateComorbidityService();

            if (service.CreateComorbidity(model))
            {
                TempData["SaveResult"] = "Comorbidity added.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Comorbidity failed to add.");

            return View(model);

        }

        public ActionResult Details(int id)
        {
            var svc = CreateComorbidityService();
            var model = svc.GetComorbidityByID(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateComorbidityService();
            var detail = service.GetComorbidityByID(id);
            var model =
                new ComorbidityEdit()
                {
                    BaseID = detail.BaseID,
                    ComorbidityID = detail.ComorbidityID
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ComorbidityEdit model)
        {
            {
                if (!ModelState.IsValid) return View(model);

                if (model.BaseID != id)
                {
                    ModelState.AddModelError("", "Wrong ID");
                    return View(model);
                }

                var service = CreateComorbidityService();

                if (service.UpdateComorbidity(model))
                {
                    TempData["SaveResult"] = "Comrobidity updated.";
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Unable to update comorbidity.");
                return View(model);

            }
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateComorbidityService();
            var model = svc.GetComorbidityByID(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteComorbidity(int id)
        {
            var service = CreateComorbidityService();

            service.DeleteComorbidity(id);

            TempData["SaveResult"] = "Comorbidity deleted.";
            return RedirectToAction("Index");
        }

        private ComorbidityService CreateComorbidityService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ComorbidityService(userId);
            return service;
        }
    }
}