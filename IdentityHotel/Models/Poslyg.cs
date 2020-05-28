

namespace IdentityHotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Poslyg
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Poslyg()
        {
            this.CPA = new HashSet<CPA>();
        }
        [Display(Name = "Послуга")]

        public int id_Poslyg { get; set; }
        [Display(Name = "Назва послуги")]
        [Required(ErrorMessage =
            "Потрібно заповнити поле \'Назва послуги\'")]
        [StringLength(50, MinimumLength = 1,
            ErrorMessage = "Назва послуги  "
            + "повинно містити від 1 до 50 символів")]
        public string Nazva_Poslyg { get; set; }
        [Display(Name = "Ціна за послугу")]
        [Range(100, 3000)]
        [Required(ErrorMessage =
       "Потрібно заповнити поле \'Ціна за послугу від 100 до 3000\'")]
        public Nullable<int> Cina_Posleg { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CPA> CPA { get; set; }
    }
}
