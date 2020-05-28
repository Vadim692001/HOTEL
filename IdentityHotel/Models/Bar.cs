
namespace IdentityHotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Bar
    {
        public int Код { get; set; }


        public int Nazva_Bary { get; set; }
        public Nullable<int> Sorname_Prac { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy/  }", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата початку роботи")]
        [Required(ErrorMessage =
         "Потрібно заповнити поле \'Дата початку роботи\'")]
        public Nullable<System.DateTime> Data { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Zv_Bary Zv_Bary { get; set; }

        
    }
}
