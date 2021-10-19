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
    public class DisorderSymptomController : Controller
    {
        // GET: DisorderSymptom
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DisorderSymptomService(userId);
            var model = service.GetDisorderSymptom();
            return View(model);
        }

        // GET:
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DisorderSymptomCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateDisorderSymptomService();

            if (service.CreateDisorderSymptom(model))
            {
                TempData["SaveResult"] = "Disorder symptom added.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Disorder symptom failed to add.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateDisorderSymptomService();
            var model = svc.GetDisorderSymptomByID(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateDisorderSymptomService();
            var detail = service.GetDisorderSymptomByID(id);
            var model =
               new DisorderSymptomEdit
               {
                   DisorderID = detail.DisorderID,
                   SymptomID = detail.SymptomID,
               };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DisorderSymptomEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ID != id)
            {
                ModelState.AddModelError("", "Wrong ID");
                return View(model);
            }

            var service = CreateDisorderSymptomService();

            if (service.UpdateDisorderSymptom(model))
            {
                TempData["SaveResult"] = "Disorder symptom updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Unable to update disorder symptom.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateDisorderSymptomService();
            var model = svc.GetDisorderSymptomByID(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSymptom(int id)
        {
            var service = CreateDisorderSymptomService();

            service.DeleteDisorderSymptom(id);

            TempData["SaveResult"] = "Disorder symptom deleted.";
            return RedirectToAction("Index");
        }

        private DisorderSymptomService CreateDisorderSymptomService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DisorderSymptomService(userId);
            return service;
        }
    }
}