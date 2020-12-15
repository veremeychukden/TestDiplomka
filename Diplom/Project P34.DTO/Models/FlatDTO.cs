using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project_P34.DTO.Models
{
   public class FlatDTO
   {
        [Required(ErrorMessage = "Введіть ціну квартири")]
        public string Price { get; set; }


        [Required(ErrorMessage = "Введіть кількість кімнат у квартирі")]
        public int Rooms { get; set; }

        [Required(ErrorMessage = "Введіть поверх квартири")]
        public int Floor { get; set; }


        [Required(ErrorMessage = "Введіть повну адресу квартири")]
        public string Address { get; set; }


        [Required(ErrorMessage = "Square id string")]
        public string SquareId { get; set; }

        [Required(ErrorMessage = "Введіть номер квартири")]
        public int Number { get; set; }

        [Required(ErrorMessage = " Вкажіть чи продана квартира?")]
        public bool Sold { get; set; }

        public string Photo { get; set; }

        public string Id { get; set; }
    }
}
