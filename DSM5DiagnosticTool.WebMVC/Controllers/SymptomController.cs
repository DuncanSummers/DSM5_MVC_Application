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
    [Authorize]
    public class SymptomController : Controller
    {
        // GET: Symptom
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SymptomService(userId);
            var model = service.GetSymptom();
            return View(model);
        }

        // GET:
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SymptomCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateSymptomService();

            if (service.CreateSymptom(model))
            {
                TempData["SaveResult"] = "Symptom added.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Symptom failed to add.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateSymptomService();
            var model = svc.GetSymptomByID(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateSymptomService();
            var detail = service.GetSymptomByID(id);
            var model =
               new SymptomEdit
               {
                   SymptomID = detail.SymptomID,
                   Description = detail.Description
               };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SymptomEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.SymptomID != id)
            {
                ModelState.AddModelError("", "Wrong ID");
                return View(model);
            }

            var service = CreateSymptomService();

            if (service.UpdateSymptom(model))
            {
                TempData["SaveResult"] = "Symptom updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Unable to update symptom.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateSymptomService();
            var model = svc.GetSymptomByID(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSymptom(int id)
        {
            var service = CreateSymptomService();

            service.DeleteSymptom(id);

            TempData["SaveResult"] = "Symptom deleted.";
            return RedirectToAction("Index");
        }


        private SymptomService CreateSymptomService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SymptomService(userId);
            return service;
        }

    }
}