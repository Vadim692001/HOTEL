

namespace IdentityHotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Number
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Number()
        {
            this.Goest = new HashSet<Goest>();
        }
        [Display(Name = "Номер")]
        public int id_Number { get; set; }
        [Display(Name = "Комплектація номера")]
        public string Komplektaci_nomera { get; set; }
        [Display(Name = "Кількість людей")]
        public Nullable<int> Kilcist_pipl { get; set; }
        [Display(Name = "Ціна")]
        public Nullable<decimal> Cina { get; set; }

        [Display(Name = "Номер")]
        [Range(0, 400)]
        [Required(ErrorMessage =
      "Потрібно заповнити поле \'Номер від 1 до 400\'")]
        public Nullable<int> Numer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Goest> Goest { get; set; }
    }
}
