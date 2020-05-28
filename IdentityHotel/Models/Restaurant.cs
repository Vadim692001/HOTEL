

namespace IdentityHotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Restaurant
    {
        [Display(Name = "Ресторан")]
        public int idRestaurant { get; set; }
        [Display(Name = "Тип рийому їжі")]
        [Required(ErrorMessage =
         "Потрібно заповнити поле \'Тип рийому їжі\'")]
        [StringLength(30, MinimumLength = 3,
         ErrorMessage = "Тип рийому їжі  "
         + "повинно містити від 3 до 30 символів")]
        public string EatingTime { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата ")]
        [Required(ErrorMessage =
       "Потрібно заповнити поле \'Дата \'")]
        public Nullable<System.DateTime> Data { get; set; }
        [Display(Name = "Працівник")]
        public Nullable<int> id_Pracivnuka { get; set; }
        [Display(Name = "Номер району")]
        public Nullable<int> District { get; set; }
        [Display(Name = "Кількість людей")]
        public Nullable<int> NumberPeople { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual NameRestaurant NameRestaurant { get; set; }
    }
}
