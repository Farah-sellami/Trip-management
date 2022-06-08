using HappyTrip.Models;
using HappyTrip.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyTrip.Controllers
{
    [Authorize(Roles = "Admin,Manager")]

    public class ChauffeurController : Controller
    {
        readonly IChauffeurRepository chauffeurRepository;
        public ChauffeurController(IChauffeurRepository chauffeurRepository)
        {
            this.chauffeurRepository = chauffeurRepository;
        }
        [AllowAnonymous]
        // GET: ChauffeurController
        public ActionResult Index()
        {
            return View(chauffeurRepository.GetAll());
        }

        // GET: ChauffeurController/Details/5
        public ActionResult Details(int id)
        {
            var chauffeur = chauffeurRepository.GetById(id);
            return View(chauffeur);
        }

        // GET: ChauffeurController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChauffeurController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Chauffeur ch)
        {
            try
            {
                chauffeurRepository.AddChauffeur(ch);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ChauffeurController/Edit/5
        public ActionResult Edit(int id)
        {
            var chauffeur = chauffeurRepository.GetById(id);
            return View(chauffeur);
        }

        // POST: ChauffeurController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Chauffeur ch)
        {
            try
            {
                chauffeurRepository.EditChauffeur(ch);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ChauffeurController/Delete/5
        public ActionResult Delete(int id)
        {
            var chauffeur = chauffeurRepository.GetById(id);
            return View(chauffeur);
        }

        // POST: ChauffeurController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Chauffeur ch)
        {
            try
            {
                chauffeurRepository.DeleteChauffeur(ch);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Search(string name)
        {
            var result = chauffeurRepository.GetAll();
            if (!string.IsNullOrEmpty(name))
                result = chauffeurRepository.FindChauffeurByName(name);
            
            
            return View("Index", result);
        }

    }
}
