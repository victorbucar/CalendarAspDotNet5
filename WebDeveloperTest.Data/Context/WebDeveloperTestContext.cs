using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDeveloperTest.Models;

namespace WebDeveloperTest.Data.Context
{
    public class WebDeveloperTestContext : DbContext
    {
        public WebDeveloperTestContext():base("name=WebDeveloperTestContext")
        {

        }
        public DbSet<Event> Events { get; set; }
    }
}
