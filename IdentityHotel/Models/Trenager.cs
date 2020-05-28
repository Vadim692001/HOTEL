


namespace IdentityHotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Trenager
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trenager()
        {
            this.SportsHall = new HashSet<SportsHall>();
        }
        [Display(Name = "Інвентар")]
        public int id_Trenegra { get; set; }
        [Display(Name = "Назва інвентаря")]
        [Required(ErrorMessage =
         "Потрібно заповнити поле \'Назва інвентаря\'")]
        [StringLength(30, MinimumLength = 1,
         ErrorMessage = "Посада  працівника  "
         + "повинна містити від 1 до 30 символів")]
        public string NazvaTrenegera { get; set; }
        [Display(Name = " Кількість інвентаря")]
        [Range(1, 20)]
        [Required(ErrorMessage =
       "Потрібно заповнити поле \'Ціна від 1 до 20\'")]
        public Nullable<int> KilcistTrenegera { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SportsHall> SportsHall { get; set; }
    }
}
