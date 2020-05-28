

namespace IdentityHotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class SuppliesGoods
    {

        public int idCosts { get; set; }
        [Display(Name = "Поставщик")]
        public Nullable<int> id_Postavchuka { get; set; }
        [Display(Name = "Товар")]
        public Nullable<int> id_Tovary { get; set; }
        [Display(Name = "Кількість")]
        [Range(1, 999)]
        [Required(ErrorMessage =
      "Потрібно заповнити поле \'Кількість від 0 до 999\'")]
        public Nullable<int> Kilkist { get; set; }
        [Display(Name = "Ціна за одиницю")]
        [Range(0.1, 999.99)]
        [Required(ErrorMessage =
      "Потрібно заповнити поле \'Ціна від 0.1 до 999.99\'")]
        public Nullable<decimal> Cina_za_odin { get; set; }
        [Display(Name = "Одиниця виміру")]
        public string Odin_vumiry { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата поставки")]
        [Required(ErrorMessage =
       "Потрібно заповнити поле \'Дата поставки\'")]
        public Nullable<System.DateTime> Data { get; set; }
        [Display(Name = "Сума")]
        public Nullable<decimal> Sum { get; set; }
        public virtual Goods Goods { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
