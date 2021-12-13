﻿using AutoVente.DAO;
using AutoVente.Extensions;
using AutoVente.Models;
using AutoVente.Service;
using AutoVente.ViewsModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace AutoVente.Controllers
{
    public class ModelController : Controller
    {
        private ModelService service;
        private CouleurService serviceCouleur;
        private MyContext context;
        public ModelController( )
        {
            service = new ModelService();
            serviceCouleur = new CouleurService();
            context =  new MyContext();
        }

        // GET: Model

        public ActionResult Index()
        {
            List<Model> models = service.GetAll().OrderBy(m => m.Nom).ToList();
            return View(models);
        }
        public ActionResult Edit(int id)
        {
            Model model = service.FindById(id);
            if (model != null)
            {
                TempData["EditModel"] = "EditModel";
                TempData["IdModel"] = model.Id;
                TempData.Keep();
            }
            return RedirectToAction("index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Model model)
        {
            if (ModelState.IsValid)
            {

                service.Update(model);
                service.SaveChanges();
                this.AddNotification("La Model " + model.Nom + " a été modifiée", NotificationType.SUCCESS);
            }
            else
            {
                TempData["EditModel"] = "EditModel";
                TempData["IdModel"] = model.Id;
                TempData.Keep();
                this.AddNotification("Echec de mise à jour de la Model " + model.Nom, NotificationType.ERROR);
            }
            return RedirectToAction("index");
        }
        public ActionResult Create()
        {

            TempData["CreateModel"] = "CreateModel";
            TempData.Keep();

            return RedirectToAction("index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ModelMarqueViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Model model = viewModel.Model;
                //model.Marque = model.
                service.Insert(model);
                service.SaveChanges();
                this.AddNotification("Creation de la" + model.Nom, NotificationType.SUCCESS);
                TempData["NomModel"] = model.Nom.ToString();
                TempData.Keep();
            }
            else
            {
                this.AddNotification("Echec de creation", NotificationType.WARNING);
                TempData["CreateModel"] = "CreateModel";
                TempData.Keep();
            }
            return RedirectToAction("index");
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            service.Delete(id);
            service.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Couleur(int id)
        {
            TempData["AddModelouleurs"+ id.ToString()] = "AddModelouleurs" + id.ToString();
            TempData.Keep();

            return RedirectToAction("index");
        }
        [HttpPost]
        public ActionResult Couleur([Bind(Include = "Id,ChekboxViewModels")] CouleurModelViewModel viewModel)
        {
            if (ModelState.IsValidField("Id") && ModelState.IsValidField("ChekboxViewModels"))
            {
                
                List<Couleur> couleurs = new List<Couleur>();
                foreach (var item in viewModel.ChekboxViewModels)
                {
                    if (item.Checked)
                    {
                        Couleur couleur = serviceCouleur.FindById(item.IdCouleur);
                        context.Models.Include(m => m.Couleurs).SingleOrDefault(x => x.Id == viewModel.Id).Couleurs.Add(couleur);

                        couleurs.Add(couleur);
                    }
                  
                }
                context.SaveChanges();
               
         
                return RedirectToAction("index");
            }
            else
            {
                TempData["AddModelouleurs"] = "AddModelouleurs";
                TempData.Keep();

                return RedirectToAction("index");
            }
          
        }
    }
}