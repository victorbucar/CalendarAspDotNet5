using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDeveloperTest.Data.Context;
using WebDeveloperTest.Domain.Repositories;
using WebDeveloperTest.Models;

namespace WebDeveloperTest.Data.Repositories
{
    public class EventRepository : IEventRepository
    {
        private WebDeveloperTestContext _context;

        public EventRepository(WebDeveloperTestContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public ICollection<Event> GetAllEvents()
        {
            return _context.Events.ToList();
        }

        public bool SaveEvent(Event ev)
        {
            //try to find if event exists
            try
            {
            var e = _context.Events.FirstOrDefault(x => x.Id == ev.Id);
            if (e == null)// event does not exist save as new
            {
                _context.Events.Add(ev);

            }
            else // exist so update data 
            {
                e.Name = ev.Name;
                e.Description = ev.Description;
                e.StartDate = ev.StartDate;
                e.FinishDate = ev.FinishDate;
            }
            _context.SaveChanges();
            return true;
            }
            catch (Exception ex)
            {
            return false;
            }
            

        }

        public bool Delete(int id)
        {
            try
            {
                var ev = _context.Events.FirstOrDefault(e => e.Id == id);
                if (ev != null)
                {
                    _context.Events.Remove(ev);
                    _context.SaveChanges();
                    
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }



    }
}
