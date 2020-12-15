﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Project_P34.DataAccess.Entity
{
    [Table("tblFlatSquareInfo")]
    public class FlatSquareInfo
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public int Rooms { get; set; }

        [Required]
        public string RoomsSquare { get; set; }

        public ICollection<Flat> Flats { get; set; }
    }
}
