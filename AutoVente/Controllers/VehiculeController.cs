using AutoVente.DAO;
using AutoVente.Extensions;
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
        private MarqueService serviceMarque;
        private CouleurService serviceCouleur;
        private MyContext context;

        public VehiculeController()
        {
            service = new VehiculeService();
            serviceModel = new ModelService();
            serviceMarque = new MarqueService();
            serviceCouleur = new CouleurService();
            context = new MyContext();
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
                Vehicule vehicule = new Vehicule(
                viewModel.Vehicule.Immatriculation,
                viewModel.Vehicule.DateMisEnCirculation,
                viewModel.Vehicule.Kilometrage,
                viewModel.Vehicule.Etat,
                viewModel.ModelId,
                viewModel.CouleurId
                );

                service.Insert(vehicule);
                service.SaveChanges();

                string modelNom = serviceModel.FindById(viewModel.ModelId).Nom;
                string MarqueNom = serviceMarque.FindById(serviceModel.FindById(viewModel.ModelId).MarqueId).Nom;

                this.AddNotification($"Creation du véhicule {MarqueNom} - {modelNom} réussi.", NotificationType.SUCCESS);
                //context.Vehicule.Add(vehicule);
                //context.SaveChanges();
            }

            return RedirectToAction("index");
        }

        //GET
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            service.Delete(id);
            service.SaveChanges();

            return RedirectToAction("index");
        }
    }
}