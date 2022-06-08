using HappyTrip.Models;
using HappyTrip.Models.Repositories;
using HappyTrip.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HappyTrip.Controllers
{
    public class ExcursionController : Controller
    {
        private IExcursionRepository excursionRepository;
        private readonly IWebHostEnvironment hostingEnvironment;
        public ExcursionController(IExcursionRepository excursionRepository, IWebHostEnvironment hostingEnvironment)
        {
            this.excursionRepository = excursionRepository;
            this.hostingEnvironment = hostingEnvironment;
        }

        // GET: ExcursionController
        public ActionResult Index()
        {
            return View(excursionRepository.GetAllExcursion());
        }

        // GET: ExcursionController/Details/5
        public ActionResult Details(int id)
        {
            var excursion = excursionRepository.GetExcursionById(id);
            return View(excursion);
        }

        // GET: ExcursionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExcursionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
               
                if (model.image != null)
                {
              
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.image.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.image.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Excursion newExcursion = new Excursion
                {
                    lieuExcur = model.lieu, 
                    description = model.description,
                    prixExcur = model.prix,
                    imageExcur = uniqueFileName
                };
                excursionRepository.AddExcursion(newExcursion);
                return RedirectToAction("details", new { id = newExcursion.idExcur });
            }
            return View();
        }

        // GET: ExcursionController/Edit/5
        public ActionResult Edit(int id)
        {
            /*var excursion = excursionRepository.GetExcursionById(id);
            return View(excursion);*/
            Excursion excursion = excursionRepository.GetExcursionById(id);
            EditViewModel excursionEditViewModel = new EditViewModel
            {
                Id = excursion.idExcur,
                lieu = excursion.lieuExcur,
                description = excursion.description,
                prix = excursion.prixExcur,
                ExistingPhotoPath = excursion.imageExcur
            };
            return View(excursionEditViewModel);

        }

        // POST: ExcursionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Excursion excursion = excursionRepository.GetExcursionById(model.Id);

                excursion.description = model.description;
                excursion.lieuExcur = model.lieu;
                excursion.prixExcur = model.prix;
                if (model.image != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    
                    excursion.imageExcur = ProcessUploadedFile(model);
                }
                Excursion updatedExcursion = excursionRepository.Update(excursion);
                if (updatedExcursion != null)
                    return RedirectToAction("index");
                else
                    return NotFound();
            }

            return View(model);
        }

        [NonAction]
        private string ProcessUploadedFile(EditViewModel model)
        {
            string uniqueFileName = null;
            if (model.image != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.image.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }


        // GET: ExcursionController/Delete/5
        public ActionResult Delete(int id)
        {
            var excursion = excursionRepository.GetExcursionById(id);
            return View(excursion);
        }

        // POST: ExcursionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Excursion e)
        {
            try
            {
                excursionRepository.DeleteExcursion(e);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Search(string lieu)
        {
            var result = excursionRepository.GetAllExcursion();
            if (!string.IsNullOrEmpty(lieu))
                result = excursionRepository.FindExcursionByLieu(lieu);
           
            return View("Index", result);
        }
    }
}
