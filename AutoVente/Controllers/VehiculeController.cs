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
        private BaseService<Photo> servicePhoto;
        private MyContext context;

        public VehiculeController()
        {
            service = new VehiculeService();
            serviceModel = new ModelService();
            serviceMarque = new MarqueService();
            serviceCouleur = new CouleurService();
            servicePhoto = new BaseService<Photo>();
            context = new MyContext();
        }

        // GET
        public ActionResult Index()
        {
            List<Vehicule> vehicules = service.GetAll().OrderBy(v => v.Model.Marque.Nom).Where(v => v.Vendu == Vendu.NON_VENDU).ToList();
            return View(vehicules);
        }

        //GET
        public ActionResult Create()
        {
            List<Model> models = serviceModel.GetAll().ToList();
            List<int> modelsPrice = new List<int>();

            foreach (var model in models)
            {
                modelsPrice.Add(model.Prix);
            }
            TempData["CreateVehicule"] = "CreateVehicule";
            TempData["modelsPrice"] = modelsPrice;
            TempData.Keep();

            return RedirectToAction("index");
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehiculeViewModel viewModel, HttpPostedFileBase photo1, HttpPostedFileBase photo2, HttpPostedFileBase photo3, HttpPostedFileBase photo4, HttpPostedFileBase photo5)
        {
            if (ModelState.IsValid)
            {
                Vehicule vehicule = new Vehicule(
                viewModel.Vehicule.Immatriculation,
                viewModel.Vehicule.DateMisEnCirculation,
                viewModel.Vehicule.Kilometrage,
                viewModel.Vehicule.Etat,
                viewModel.ModelId,
                viewModel.CouleurId,
                viewModel.Prix
                );

                service.Insert(vehicule);
                service.SaveChanges();

                List<HttpPostedFileBase> photos = new List<HttpPostedFileBase>();
                photos.Add(photo1);
                photos.Add(photo2);
                photos.Add(photo3);
                photos.Add(photo4);
                photos.Add(photo5);

                var number = 1;
                foreach (var photo in photos)
                {
                    if (photo != null)
                    {
                        string fileName = number + "_" + vehicule.Immatriculation + photo.FileName; //Personaliser le nom de la photo
                        string path = Server.MapPath("~/Content/img/Vehicules/" + fileName);
                        photo.SaveAs(path);

                        Photo p = new Photo("/Content/img/Vehicules/" + fileName, number, vehicule.Immatriculation);
                        servicePhoto.Insert(p);
                        servicePhoto.SaveChanges();

                        number++;
                    }
                }

                string modelNom = serviceModel.FindById(viewModel.ModelId).Nom;
                string MarqueNom = serviceMarque.FindById(serviceModel.FindById(viewModel.ModelId).MarqueId).Nom;

                this.AddNotification($"Creation du véhicule {MarqueNom} - {modelNom} réussi.", NotificationType.SUCCESS);
            }

            return RedirectToAction("index");
        }

        //GET
        [HttpPost]
        public ActionResult Delete(int id)
        {
            service.Delete(id);
            service.SaveChanges();

            this.AddNotification($"Véhicule supprimé.", NotificationType.SUCCESS);

            return RedirectToAction("index");
        }

        public ActionResult Edit(int id)
        {
            Vehicule vehicule = service.FindById(id);
            if (vehicule != null)
            {
                TempData["EditVehicule"] = "EditVehicule";
                TempData["IdVehicule"] = vehicule.Id;
                TempData.Keep();
            }
            return RedirectToAction("index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Vehicule v)
        {
            Vehicule vehicule = service.FindByImmatriculation(v.Immatriculation);

            if (ModelState.IsValidField("Kilometrage") && ModelState.IsValidField("Etat") && ModelState.IsValidField("Prix"))
            {
                vehicule.Kilometrage = v.Kilometrage;
                vehicule.Etat = v.Etat;
                vehicule.Prix = v.Prix;

                service.Update(vehicule);
                service.SaveChanges();
                this.AddNotification($"Modification du véhicule réussi.", NotificationType.SUCCESS);
            }
            else
            {
                TempData["EditVehicule"] = "EditVehicule";
                TempData["IdVehicule"] = vehicule.Immatriculation;
                TempData.Keep();
                //this.AddNotification($"Echec de mise à jour du véhicule {vehicule.Model.Marque.Nom} - {vehicule.Model.Nom}.", NotificationType.ERROR);
            }
            return RedirectToAction("index");
        }
    }
}