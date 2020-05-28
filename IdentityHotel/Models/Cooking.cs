

namespace IdentityHotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Cooking
    {
        public int Код { get; set; }

        [Display(Name = "Страва")]
        public int id_Strav { get; set; }

        [Display(Name = "Продукт")]
        public Nullable<int> id_Tovary { get; set; }

        [Display(Name = "Маса")]
        [Range(1, 999.99)]
        [Required(ErrorMessage =
       "Потрібно заповнити поле \'Маса від 1 до 999.99\'")]
        public Nullable<int> masa { get; set; }

        [Display(Name = "Одиниці виміру")]
        public string Odun_vumiry { get; set; }
        [Display(Name = "Відділ кухні")]
        public Nullable<int> id_Vidila_kyx { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата приготування")]
        [Required(ErrorMessage =
        "Потрібно заповнити поле \'Дата приготування\'")]
        public Nullable<System.DateTime> Data { get; set; }
        public virtual Dishes Dishes { get; set; }
        public virtual Goods Goods { get; set; }
        public virtual Vidil_kyx Vidil_kyx { get; set; }
    }
}
