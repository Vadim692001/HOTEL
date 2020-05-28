
namespace IdentityHotel.Models
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.Bar = new HashSet<Bar>();
            this.CPA = new HashSet<CPA>();
            this.Restaurant = new HashSet<Restaurant>();
            this.SportsHall = new HashSet<SportsHall>();
            this.ZPEmployee = new HashSet<ZPEmployee>();
            this.ZPEmployee1 = new HashSet<ZPEmployee>();
            this.ZPEmployee2 = new HashSet<ZPEmployee>();
        }

        public int id_Pracivnuca { get; set; }
        [Display(Name = "Прізвище")]
        [Required(ErrorMessage =
            "Потрібно заповнити поле \'Прізвище\'")]
        [StringLength(30, MinimumLength = 3,
            ErrorMessage = "Прізвище  працівника  "
            + "повинно містити від 3 до 30 символів")]
        public string Sorname_Prac { get; set; }
        [Display(Name = "І'мя")]
        [Required(ErrorMessage =
         "Потрібно заповнити поле \'І'мя\'")]
        [StringLength(30, MinimumLength = 3,
         ErrorMessage = "І'мя  працівника  "
         + "повинно містити від 3 до 30 символів")]
        public string Name_Prac { get; set; }
        [Display(Name = "По батькові")]
        [Required(ErrorMessage =
         "Потрібно заповнити поле \'По батькові\'")]
        [StringLength(30, MinimumLength = 3,
         ErrorMessage = "По батькові працівника   "
         + "повинен містити від 3 до 30 символів")]
        public string Pobat_Prac { get; set; }
        [Display(Name = "Посада")]
        [Required(ErrorMessage =
         "Потрібно заповнити поле \'Посада\'")]
        [StringLength(30, MinimumLength = 3,
         ErrorMessage = "Посада  працівника  "
         + "повинна містити від 3 до 30 символів")]
        public string Work { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата початку роботи")]
        [Required(ErrorMessage =
         "Потрібно заповнити поле \'Дата початку роботи\'")]
        public Nullable<System.DateTime> Data_pochatcy { get; set; }
        [Display(Name = "Дата завершення роботи")]
        public Nullable<System.DateTime> Data_kinc { get; set; }

        [Display(Name = "Заробітна карта")]
        [Required(ErrorMessage =
         "Потрібно заповнити поле \'Заробітна карта\'")]
        [RegularExpression(@"^(\d{8})$")]
        public Nullable<int> Cardca_ZP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bar> Bar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CPA> CPA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Restaurant> Restaurant { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SportsHall> SportsHall { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ZPEmployee> ZPEmployee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ZPEmployee> ZPEmployee1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ZPEmployee> ZPEmployee2 { get; set; }
    }
}
