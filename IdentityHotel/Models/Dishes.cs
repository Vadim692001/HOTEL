

namespace IdentityHotel.Models
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Dishes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dishes()
        {
            this.Cooking = new HashSet<Cooking>();
        }
        [Display(Name = "Страва")]
        public int id_Strav { get; set; }
        [Display(Name = "Назва страви")]
        [Required(ErrorMessage =
         "Потрібно заповнити поле \'Назва страви\'")]
        [StringLength(40, MinimumLength = 1,
         ErrorMessage = "Назва страви  "
         + "повинно містити від 1 до 40 символів")]
        public string Nazva_Strav { get; set; }
        [Display(Name = "Вид страви")]
        public string Vud_Strav { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cooking> Cooking { get; set; }
    }
}
