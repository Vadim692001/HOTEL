


namespace IdentityHotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Goods
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Goods()
        {
            this.Cooking = new HashSet<Cooking>();
            this.SuppliesGoods = new HashSet<SuppliesGoods>();
        }


        public Nullable<int> id_Sklady { get; set; }
        [Display(Name = "Товар")]

        public int id_Goods { get; set; }
        [Display(Name = "Продукт")]
        [Required(ErrorMessage =
            "Потрібно заповнити поле \'Продукт\'")]
        [StringLength(30, MinimumLength = 3,
            ErrorMessage = "Продукт    "
            + "повинно містити від 3 до 30 символів")]
        public string Tovar { get; set; }
        [Display(Name = "Кількість")]
        [Range(1, 999)]
        [Required(ErrorMessage =
       "Потрібно заповнити поле \'Кількість від 1 до 999\'")]
        public Nullable<int> Kilcist { get; set; }
        [Display(Name = "Одиниці вимірювання")]
        public string Unit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cooking> Cooking { get; set; }
        public virtual Sklad Sklad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SuppliesGoods> SuppliesGoods { get; set; }
    }
}
