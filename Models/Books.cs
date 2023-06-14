using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlirezaAbasi.Models
{
    public class Books
    {
        [Key]
        public int Code { get; set; }
        [Required]
        [MaxLength(100)]
        [Column(TypeName = "varchar")]
        public string Title { get; set; }
        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string Writer { get; set; }

        public virtual AssignedBooks AssignedBooks  { get; set; }
    }
}