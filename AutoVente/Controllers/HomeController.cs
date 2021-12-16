using AutoVente.Models;
using AutoVente.Service;
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
            if (id != null)
            {
                try
                {

                    switch (id)
                    {
                        case  1:
                           voitures = modelService.FindByType(Models.Type.BREAK);
                            break;
                        case 2:
                            voitures = modelService.FindByType(Models.Type.CITADINE);
                            break;
                        case 3:
                            voitures = modelService.FindByType(Models.Type.ROUTIERE);
                            break;
                        case 4:
                            voitures = modelService.FindByType(Models.Type.SPROTIVE);
                            break;
                        case 5:
                            voitures = modelService.FindByType(Models.Type.MONOSPACE);
                            break;
                        case 6:
                            voitures = modelService.FindByType(Models.Type.SUV);
                            break;
                        case 7:
                            voitures = modelService.FindByType(Models.Type.LUDOSPACE);
                            break;
                        case 8:
                            voitures = modelService.FindByType(Models.Type.BERLINE);
                            break;

                    }

                }
                catch (Exception)
                {

                    return HttpNotFound();
                }
               
            }
            else
            {
                voitures = vehiculeService.GetAll().OrderBy(v => v.Prix).ToList();
               
            }

            SviewModel.Vehicules = voitures;
            return View(SviewModel);
        }
        [HttpPost]
        public ActionResult Search([Bind(Include = "IdModel")] SearchViewModel SviewModel)
        {
            if (ModelState.IsValid)
            {

            }
            return View(SviewModel);
        }
    }
}