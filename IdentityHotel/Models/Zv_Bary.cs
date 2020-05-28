

namespace IdentityHotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Zv_Bary
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Zv_Bary()
        {
            this.Bar = new HashSet<Bar>();
        }
        [Display(Name = "Назва бару")]
        public int id_Bary { get; set; }
        [Display(Name = "Назва бару")]
        [Required(ErrorMessage =
         "Потрібно заповнити поле \'Назва бару\'")]
        [StringLength(30, MinimumLength = 1,
         ErrorMessage = "Назва бару  "
         + "повинна містити від 1 до 30 символів")]
        public string Nazva_Bary { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bar> Bar { get; set; }
    }
}
