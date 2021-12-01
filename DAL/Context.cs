using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Centric_FINAL.Models;

namespace Centric_FINAL.DAL
{
    public class Context : DbContext
    {
        public Context() : base("name=DefaultConnection")
        {

        }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Recognize> Recognize { get; set; }

    }
}