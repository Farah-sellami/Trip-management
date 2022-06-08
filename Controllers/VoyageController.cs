using HappyTrip.Models;
using HappyTrip.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyTrip.Controllers
{
    public class VoyageController : Controller
    {
        readonly IVoyageRepository voyagerepository;
        readonly IAutobusRepository autobusrepository;
        readonly IChauffeurRepository chauffeurrepository;
        readonly IExcursionRepository excursionrepository;

        public VoyageController ( IVoyageRepository voyagerepository, 
            IAutobusRepository autobusrepository, 
            IChauffeurRepository chauffeurrepository,
            IExcursionRepository excursionrepository)
        {
            this.voyagerepository = voyagerepository;
            this.autobusrepository = autobusrepository;
            this.chauffeurrepository = chauffeurrepository;
            this.excursionrepository = excursionrepository; 
        }
        // GET: VoyageController
        public ActionResult Index()
        {
            ViewBag.idExcur = new SelectList(excursionrepository.GetAllExcursion(), "idExcur", "lieuExcur");
            ViewBag.idAutobus = new SelectList(autobusrepository.GetAll(), "idAutobus", "matricule");
            ViewBag.idChauffeur = new SelectList(chauffeurrepository.GetAll(), "idChauffeur", "nomChauffeur");
            return View(voyagerepository.GetAll());
                                 
        }

        // GET: VoyageController/Details/5
        public ActionResult Details(int id)
        {
            return View(voyagerepository.GetById(id));
        }

        // GET: VoyageController/Create
        public ActionResult Create()
        {
           
            ViewBag.idAutobus = new SelectList(autobusrepository.GetAll(), "idAutobus", "matricule");
            ViewBag.idChauffeur = new SelectList(chauffeurrepository.GetAll(), "idChauffeur", "nomChauffeur");
            ViewBag.idExcur = new SelectList(excursionrepository.GetAllExcursion(), "idExcur", "lieuExcur");
            return View();
        }

        // POST: VoyageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Voyage v)
        {
            try
            {
                ViewBag.idAutobus = new SelectList(autobusrepository.GetAll(), "idAutobus", "matricule" , v.idAutobus);
                ViewBag.idChauffeur = new SelectList(chauffeurrepository.GetAll(), "idChauffeur", "nomChauffeur" , v.idChauffeur);
                ViewBag.idExcur = new SelectList(excursionrepository.GetAllExcursion(), "idExcur", "lieuExcur", v.idExcur);
                voyagerepository.AddVoyage(v);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VoyageController/Edit/5
        public ActionResult Edit(int id)
        {
            
            ViewBag.idAutobus = new SelectList(autobusrepository.GetAll(), "idAutobus", "matricule");
            ViewBag.idChauffeur = new SelectList(chauffeurrepository.GetAll(), "idChauffeur", "nomChauffeur");
            ViewBag.idExcur = new SelectList(excursionrepository.GetAllExcursion(), "idExcur", "lieuExcur");
            return View(voyagerepository.GetById(id));
        }

        // POST: VoyageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Voyage v)
        {
            try
            {
                
                ViewBag.idAutobus = new SelectList(autobusrepository.GetAll(), "idAutobus", "matricule");
                ViewBag.idChauffeur = new SelectList(chauffeurrepository.GetAll(), "idChauffeur", "nomChauffeur");
                ViewBag.idExcur = new SelectList(excursionrepository.GetAllExcursion(), "idExcur", "lieuExcur");
                voyagerepository.EditVoyage(v);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VoyageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(voyagerepository.GetById(id));
        }

        // POST: VoyageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Voyage v)
        {
            try
            {
                voyagerepository.DeleteVoyage(v);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
