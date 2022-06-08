
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

    public class AutobusController : Controller
    {
        readonly IAutobusRepository autobusRepository;
        public AutobusController(IAutobusRepository autobusRepository)
        {
            this.autobusRepository = autobusRepository;
        }
        [AllowAnonymous]
        // GET: AutobusController
        public ActionResult Index()
        {
            return View(autobusRepository.GetAll());
        }

        // GET: AutobusController/Details/5
        public ActionResult Details(int id)
        {
            var autobus = autobusRepository.GetAutobusById(id);
            return View(autobus);
        }

        // GET: AutobusController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AutobusController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Autobus a)
        {
            try
            {
                autobusRepository.AddAutobus(a);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AutobusController/Edit/5
        public ActionResult Edit(int id)
        {
            var autobus = autobusRepository.GetAutobusById(id);
            return View(autobus);
        }

        // POST: AutobusController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Autobus a)
        {
            try
            {
                autobusRepository.EditAutobus(a);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AutobusController/Delete/5
        public ActionResult Delete(int id)
        {
            var autobus = autobusRepository.GetAutobusById(id);
            return View(autobus);
        }

        // POST: AutobusController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Autobus a)
        {
            try
            {

                autobusRepository.DeleteAutobus(a);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
