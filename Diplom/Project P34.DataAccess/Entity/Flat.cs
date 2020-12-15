using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Project_P34.DataAccess.Entity
{
    [Table("tblFlat")]
    public class Flat
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public int Rooms { get; set; }
        [Required]
        public int Floor { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string SquareId { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public bool Sold { get; set; }
        [Required]
        public string Photo { get; set; }
        public virtual FlatSquareInfo FlatSquareInfo { get; set; }

    }
}
