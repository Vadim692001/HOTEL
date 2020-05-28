

namespace IdentityHotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class DrinksВar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DrinksВar()
        {
            this.BarSupplies = new HashSet<BarSupplies>();
        }
        [Display(Name = "Нопої")]
        public int id_Napo { get; set; }
        [Display(Name = "Назва нопою")]
        [Required(ErrorMessage =
            "Потрібно заповнити поле \'Назва нопою\'")]
        [StringLength(30, MinimumLength = 3,
            ErrorMessage = "Назва нопою  "
            + "повинно містити від 3 до 30 символів")]
        public string Nazva_Napo { get; set; }
        [Display(Name = "Склад")]
        public Nullable<int> id_Sklady { get; set; }
        [Display(Name = "Кількість")]
        public Nullable<int> Kilcist_v_Litrax { get; set; }
        [Display(Name = "Країна виробник")]
        public string Cantri_vurob { get; set; }
        [Display(Name = "Обороти")]
        public string Oborot { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BarSupplies> BarSupplies { get; set; }
        public virtual Sklad Sklad { get; set; }
    }
}
