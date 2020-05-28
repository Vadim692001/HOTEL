

namespace IdentityHotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class CPA
    {
        public int Код { get; set; }
        [Display(Name = "Працівник працівника")]
        public Nullable<int> id_Pracivnuca { get; set; }
        public Nullable<int> id_Goct { get; set; }
        [Display(Name = "І'мя гостя")]
        public Nullable<int> NameGoct { get; set; }
        [Display(Name = "Послуга")]
        public Nullable<int> id_Poslyg { get; set; }
        [DataType(DataType.Time)]
        [Display(Name = "Дата початку процедури")]
        [Required(ErrorMessage =
      "Потрібно заповнити поле \'Дата початку процедури\'")]
        public Nullable<System.DateTime> TeamPochatky { get; set; }
        [DataType(DataType.Time)]
        [Display(Name = "Дата завершення процедури ")]
        [Required(ErrorMessage =
    "Потрібно заповнити поле \'Дата завершення процедури\'")]
        public Nullable<System.DateTime> TeamKin { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Goest Goest { get; set; }
        public virtual Poslyg Poslyg { get; set; }
    }
}
