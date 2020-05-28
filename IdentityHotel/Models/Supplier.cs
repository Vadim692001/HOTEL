

namespace IdentityHotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            this.BarSupplies = new HashSet<BarSupplies>();
            this.SuppliesGoods = new HashSet<SuppliesGoods>();
        }

        public int id_Supplier { get; set; }
        [Display(Name = "Поставщик")]
        [Required(ErrorMessage =
            "Потрібно заповнити поле \'Поставщик\'")]
        [StringLength(50, MinimumLength = 1,
            ErrorMessage = "Назва поставщика  "
            + "повинно містити від 1 до 50 символів")]
        public string Nazva_Postavchuca { get; set; }
        [Display(Name = "Місто")]
        public string Misto { get; set; }
        [Display(Name = "Країна")]
        public string Contri { get; set; }
        [Display(Name = "Рахунок")]
        [Required(ErrorMessage =
         "Потрібно заповнити поле \'Рахунок\'")]
        [RegularExpression(@"^(\d{8})$")]
        public Nullable<int> Raxynoc_perovody { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BarSupplies> BarSupplies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SuppliesGoods> SuppliesGoods { get; set; }
    }
}
