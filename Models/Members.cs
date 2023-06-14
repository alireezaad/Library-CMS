using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AlirezaAbasi.Models
{
    public class Members
    {
        [Key]
        public int RegisterCode  { get; set; }
        [Required]
        [MaxLength(50)]
        [Column(TypeName ="varchar")]
        public string FullName  { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime BirthDate { get; set; }
        [MaxLength(200)]
        [Column(TypeName = "varchar")]
        public string Address { get; set; }

        public virtual ICollection<AssignedBooks> AssignedBooks { get; set; }
    }
}