

namespace IdentityHotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class BarSupplies
    {
        public int idCost { get; set; }

        [Display(Name = "Назва поставщика")]
        public Nullable<int> id_Postavchuka { get; set; }


        [Display(Name = "Нопої")]
        public Nullable<int> id_Napo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата початку роботи")]
        [Required(ErrorMessage =
       "Потрібно заповнити поле \'Дата поставки\'")]
        public Nullable<System.DateTime> Date { get; set; }

        [Display(Name = "Кількість")]
        [Range(0, 999)]
        [Required(ErrorMessage =
       "Потрібно заповнити поле \'Кількість від 0 до 999\'")]
        public Nullable<int> Number { get; set; }
        [Display(Name = "Одиниця виміру")]
        public string Unit { get; set; }
        [Display(Name = "Ціна за одиницю")]
        [Range(0, 999.99)]
        [Required(ErrorMessage =
       "Потрібно заповнити поле \'Ціна від 0 до 999.99\'")]
        public Nullable<int> Pric { get; set; }
        [Display(Name = "Сума")]
        public Nullable<int> Sum { get; set; }

        public virtual DrinksВar DrinksВar { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
