﻿using AutoVente.Models;
using AutoVente.Service;
using AutoVente.Tools;
using AutoVente.ViewsModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoVente.Controllers
{
 
    public class HomeController : Controller
    {
        private VehiculeService vehiculeService;
        private ModelService modelService;
        private MarqueService marqueService;

        public HomeController()
        {
            vehiculeService = new VehiculeService();
            modelService = new ModelService();
            marqueService = new MarqueService();
        }

        public ActionResult Index()
        {
            return View();
        }
 
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

     
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        [HttpGet]
        public ActionResult Search(int? id)
        {
            SearchViewModel SviewModel = new SearchViewModel();
            List<Vehicule> voitures = new List<Vehicule>();
            SviewModel.Marques = marqueService.GetAll().ToList();
            SviewModel.Models = modelService.GetAll().ToList();
            voitures = vehiculeService.GetVehiculesWithPricipalPhoto();
            if (id != null)
            {
                try
                {

                    switch (id)
                    {
                        case  1:
                           voitures = voitures.Where(v => v.Model.Type == Models.Type.BREAK).ToList();
                            break;
                        case 2:
                            voitures = voitures.Where(v => v.Model.Type == Models.Type.CITADINE).ToList();
                            break;
                        case 3:
                            voitures = voitures.Where(v => v.Model.Type == Models.Type.ROUTIERE).ToList();
                            
                            break;
                        case 4:
                            voitures = voitures.Where(v => v.Model.Type == Models.Type.SPOROTIVE).ToList();

                            break;
                        case 5:
                            voitures = voitures.Where(v => v.Model.Type == Models.Type.MONOSPACE).ToList();

                            break;
                        case 6:
                            voitures = voitures.Where(v => v.Model.Type == Models.Type.SUV).ToList();

                            break;
                        case 7:
                            voitures = voitures.Where(v => v.Model.Type == Models.Type.LUDOSPACE).ToList();

                            break;
                        case 8:
                            voitures = voitures.Where(v => v.Model.Type == Models.Type.BERLINE).ToList();
                            break;

                    }

                }
                catch (Exception)
                {

                    return HttpNotFound();
                }
               
            }
           

            SviewModel.Vehicules = voitures;
            return View(SviewModel);
        }
        [HttpPost]
        public ActionResult Search( SearchViewModel SviewModel)
        {
            if (ModelState.IsValid)
            {
                SviewModel.Marques = marqueService.GetAll().ToList();
                SviewModel.Models = modelService.GetAll().ToList();
                Carburent carburent = MyMethodes.GetValueCarburent(SviewModel.Carburent.ToString());
                BoiteVitesse boiteVitesse = MyMethodes.GetValueBoiteVitesse(SviewModel.BoiteVitesse.ToString());

                List<Vehicule> vehicules = new List<Vehicule>();

                if (SviewModel.ModelId != 0)
                {
                    vehicules = modelService.FindByIdModel(SviewModel.ModelId, carburent, boiteVitesse);
                }
                else
                {
                    vehicules = modelService.SearchModel(SviewModel.AnneeMin, SviewModel.AnneeMax, carburent, MyMethodes.GetValueType(SviewModel.Type.ToString()), boiteVitesse, SviewModel.MarqueId);
                }

                SviewModel.Vehicules = vehiculeService.SearchVehicule(vehicules, SviewModel.kilometrageMin, SviewModel.kilometrageMax, SviewModel.PrixMin, SviewModel.PrixMax, SviewModel.Etat);

                

            }
            return View(SviewModel);
        }
        [HttpGet]
        public ActionResult DetailVehicule(int id)
        {
            if (id != 0)
            {
                return View(vehiculeService.GetDetailVehicule(id));
            }
            return HttpNotFound();


        }
    }
}