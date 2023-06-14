using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlirezaAbasi.Models
{
    public class AssignedBooks
    {
        public AssignedBooks()
        {
            books = new Collection<Books>();
        }
        [Key]
        public int Id { get; set; }
        public Members members { get; set; }
        public ICollection<Books> books { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}