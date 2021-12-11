using AutoVente.Models;
using AutoVente.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoVente.Controllers
{
    public class ModelController : Controller
    {
        private ModelService service;

        public ModelController( )
        {
            service = new ModelService();
        }

        // GET: Model

        public ActionResult Index()
        {
            List<Model> models = service.GetAll().OrderBy(m => m.Nom).ToList();
            return View(models);
        }
    }
}