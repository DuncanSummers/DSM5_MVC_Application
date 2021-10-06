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
    public class DisorderController : Controller
    {
        // GET: Disorder
        public ActionResult Index()
        {
            return View();
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DisorderCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateDisorderService();

            if (service.CreateDisorder(model))
            {
                TempData["SaveResult"] = "Disorder added.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Disorder failed to add.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateDisorderService();
            var model = svc.GetDisorderByID(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateDisorderService();
            var detail = service.GetDisorderByID(id);
            var model =
               new DisorderEdit
               {
                   DisorderID = detail.DisorderID,
                   ICD = detail.ICD,
                   Category = detail.Category,
                   DisorderName = detail.DisorderName,
                   Symptoms = detail.Symptoms,
                   Comorbidities = detail.Comorbidities
               };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DisorderEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.DisorderID != id)
            {
                ModelState.AddModelError("", "Wrong ID");
                return View(model);
            }

            var service = CreateDisorderService();
            
            if (service.UpdateDisorder(model))
            {
                TempData["SaveResult"] = "Disorder updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Unable to update disorder.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateDisorderService();
            var model = svc.GetDisorderByID(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDisorder(int id)
        {
            var service = CreateDisorderService();

            service.DeleteDisorder(id);

            TempData["SaveResult"] = "Disorder deleted.";
            return RedirectToAction("Index");
        }

        private DisorderService CreateDisorderService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DisorderService(userId);
            return service;
        }
    }
}