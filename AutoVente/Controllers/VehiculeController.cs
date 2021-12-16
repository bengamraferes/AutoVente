using AutoVente.Models;
using AutoVente.Service;
using AutoVente.ViewsModels;
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
        private ModelService serviceModel;
        private CouleurService serviceCouleur;

        public VehiculeController()
        {
            service = new VehiculeService();
            serviceModel = new ModelService();
            serviceCouleur = new CouleurService();
        }

        // GET
        public ActionResult Index()
        {
            List<Vehicule> vehicules = service.GetAll().OrderBy(v => v.Model.Marque.Nom).OrderByDescending(v => v.Model.Nom).ToList();
            return View(vehicules);
        }

        //GET
        public ActionResult Create()
        {

            TempData["CreateVehicule"] = "CreateVehicule";
            TempData.Keep();

            return RedirectToAction("index");
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehiculeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Model mdl = serviceModel.FindById(viewModel.ModelId);
                Couleur couleur = serviceCouleur.FindById(viewModel.CouleurId);

                Vehicule vehicule = new Vehicule(
                viewModel.Vehicule.Immatriculation,
                viewModel.Vehicule.DateMisEnCirculation,
                viewModel.Vehicule.Kilometrage,
                viewModel.Vehicule.Etat,
                mdl,
                couleur
                );

                service.Insert(vehicule);
                service.SaveChanges();
            }

            return RedirectToAction("index");
        }
    }
}