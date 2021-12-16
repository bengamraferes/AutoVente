using AutoVente.Models;
using AutoVente.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoVente.Controllers
{
    public class VehiculeController : Controller
    {
        private VehiculeService service;

        public VehiculeController()
        {
            service = new VehiculeService();
        }

        // GET
        public ActionResult Index()
        {
            List<Vehicule> vehicules = service.GetAll().OrderBy(v => v.Model.Marque.Nom).ToList();
            return View(vehicules);
        }

        //GET
        public ActionResult Create()
        {

            TempData["CreateVehicule"] = "CreateVehicule";
            TempData.Keep();

            return RedirectToAction("index");
        }
    }
}