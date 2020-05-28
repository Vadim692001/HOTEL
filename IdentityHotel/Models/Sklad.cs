

namespace IdentityHotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Sklad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sklad()
        {
            this.DrinksВar = new HashSet<DrinksВar>();
            this.Goods = new HashSet<Goods>();
        }
        [Display(Name = " Номер склад")]
        public int id_Sklady { get; set; }
        [Display(Name = " Назва склад")]
        [Required(ErrorMessage =
            "Потрібно заповнити поле \'Склад\'")]
        [StringLength(30, MinimumLength = 3,
            ErrorMessage = "Склад  "
            + "повинно містити від 3 до 30 символів")]
        public string Nam_sk { get; set; }
        [Display(Name = "Тип збереження")]
        [Required(ErrorMessage =
            "Потрібно заповнити поле \'Тип збереження\'")]
        [StringLength(30, MinimumLength = 3,
            ErrorMessage = "Тип збереження  "
            + "повинно містити від 3 до 30 символів")]
        public string Tip_zber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DrinksВar> DrinksВar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Goods> Goods { get; set; }
    }
}
