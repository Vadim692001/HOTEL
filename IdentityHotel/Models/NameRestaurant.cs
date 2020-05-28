

namespace IdentityHotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class NameRestaurant
    {
        public int id_Restaurant { get; set; }
        [Display(Name = "Назва ресторану")]
        [Required(ErrorMessage =
           "Потрібно заповнити поле \'Назва ресторану\'")]
        [StringLength(50, MinimumLength = 3,
           ErrorMessage = "Назва ресторану  "
           + "повинно містити від 3 до 50 символів")]
        public string NameRestaurant1 { get; set; }
    
        public virtual Restaurant Restaurant { get; set; }
    }
}
