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

        // GET: Message
        public ActionResult Index()
        {
            List<Message> messages = service.GetAll().ToList();
            return View(messages);
        }
    }
}