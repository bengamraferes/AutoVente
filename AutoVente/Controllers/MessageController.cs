using AutoVente.Extensions;
using AutoVente.Models;
using AutoVente.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoVente.Controllers
{
    public class MessageController : Controller
    {
        private BaseService<Message> service;

        public MessageController()
        {
            service = new BaseService<Message>();
        }

        // GET
        public ActionResult Index()
        {
            List<Message> messages = service.GetAll().ToList();
            return View(messages);
        }

        // GET
        public ActionResult Contact()
        {
            Message message = new Message();
            return View(message);
        }

        // GET
        public ActionResult Details(int id)
        {
            Message message = service.FindById(id);

            message.EtatMessage = EtatsMessage.OUVERT;
            service.Update(message);
            service.SaveChanges();

            return View(message);
        }

        // POST
        [HttpPost]
        public ActionResult Delete(int id)
        {
            service.Delete(id);
            service.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET
        public ActionResult ChangeEtat(int id)
        {
            Message message = service.FindById(id);

            if (message.EtatMessage == EtatsMessage.OUVERT)
            {
                message.EtatMessage = EtatsMessage.FERME;
            }
            else
            {
                message.EtatMessage = EtatsMessage.OUVERT;
            }

            service.Update(message);
            service.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}