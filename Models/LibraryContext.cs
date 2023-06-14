using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AlirezaAbasi.Models
{
    public class LibraryContext:DbContext
    {
        public DbSet<Members> Members { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<AssignedBooks> AssignedBooks { get; set; }
    }
}