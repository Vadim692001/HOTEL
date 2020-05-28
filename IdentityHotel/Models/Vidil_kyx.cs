
namespace IdentityHotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Vidil_kyx
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vidil_kyx()
        {
            this.Cooking = new HashSet<Cooking>();
        }
        [Display(Name = "Відділу")]
        public int id_Vidila_kyx { get; set; }
        [Display(Name = "Назва відділу")]
        [Required(ErrorMessage =
               "Потрібно заповнити поле \'Назва відділу\'")]
        [StringLength(30, MinimumLength = 3,
               ErrorMessage = "Назва відділу  "
               + "повинна містити від 3 до 30 символів")]
        public string Nazva_vidily { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cooking> Cooking { get; set; }
    }
}
