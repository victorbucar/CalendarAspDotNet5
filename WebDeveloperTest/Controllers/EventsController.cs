using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDeveloperTest.App_Start;
using WebDeveloperTest.Domain.Repositories;
using WebDeveloperTest.Models;

namespace WebDeveloperTest.Controllers
{
    public class EventsController : Controller
    {
        private IEventRepository _eventRepository;

        public EventsController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        // GET: Events
        [JsonNetFilter]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [JsonNetFilter]
        [HttpGet]
        [Route("getevents")]
        public ActionResult GetEvents()
        {
            var events = _eventRepository.GetAllEvents();
            return Json(events, JsonRequestBehavior.AllowGet);
            //return View();
        }
        [JsonNetFilter]
        [HttpPost]
        [Route("saveevent")]
        public ActionResult SaveEvent(Event ev)
        {
            var status = false;
            status = _eventRepository.SaveEvent(ev);


            return Json(status, JsonRequestBehavior.AllowGet);
        }

        //[JsonNetFilter]
        [HttpPost]
        [Route("deleteevent")]
        public ActionResult DeleteEvent(int id)
        {
            var status = _eventRepository.Delete(id);

            return Json(status, JsonRequestBehavior.AllowGet);
        }

       
    }
}