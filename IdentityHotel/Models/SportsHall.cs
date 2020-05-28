
namespace IdentityHotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class SportsHall
    {
        public int Код { get; set; }
        [Display(Name = "Працівник")]
        public Nullable<int> id_Pracivnuca { get; set; }
        [Display(Name = "Вид інвентаря")]
        public Nullable<int> id_Trenegra { get; set; }
        [Display(Name = "Гость")]
        public Nullable<int> id_Goct { get; set; }
        [DataType(DataType.Time)]
        [Display(Name = "Дата ")]
        [Required(ErrorMessage =
     "Потрібно заповнити поле \'Дата \'")]
        public Nullable<System.DateTime> Data { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Goest Goest { get; set; }
        public virtual Trenager Trenager { get; set; }
    }
}
