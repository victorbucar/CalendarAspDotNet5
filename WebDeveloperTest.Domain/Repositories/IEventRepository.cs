using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDeveloperTest.Models;

namespace WebDeveloperTest.Domain.Repositories
{
    public interface IEventRepository : IDisposable
    {
        ICollection<Event> GetAllEvents();
        bool SaveEvent(Event ev);
        bool Delete(int id);

    }
}
