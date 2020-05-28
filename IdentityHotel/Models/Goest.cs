

namespace IdentityHotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Goest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Goest()
        {
            this.CPA = new HashSet<CPA>();
            this.SportsHall = new HashSet<SportsHall>();
        }

        public int IdGoest { get; set; }
        [Display(Name = "Комплектація номера")]
        public int IdNumber { get; set; }
        [Display(Name = "Прізвище")]
        [Required(ErrorMessage =
    "Потрібно заповнити поле \'Прізвище\'")]
        [StringLength(30, MinimumLength = 3,
    ErrorMessage = "Прізвище  гостя  "
    + "повинно містити від 3 до 30 символів")]
        public string SornameGoesst { get; set; }
        [Display(Name = "І'мя")]
        [Required(ErrorMessage =
        "Потрібно заповнити поле \'І'мя\'")]
        [StringLength(30, MinimumLength = 3,
        ErrorMessage = "І'мя  гостя  "
        + "повинно містити від 3 до 30 символів")]
        public string NameGoest { get; set; }

        [Display(Name = "По батькові")]
        [Required(ErrorMessage =
        "Потрібно заповнити поле \'По батькові\'")]
        [StringLength(30, MinimumLength = 3,
        ErrorMessage = "По батькові гостя   "
        + "повинен містити від 3 до 30 символів")]
        public string SurnameGoest { get; set; }
        [Display(Name = "Вік")]
        [Range(18, 130)]
        [Required(ErrorMessage =
      "Потрібно заповнити поле \'Вік від 18 до 130\'")]
        public Nullable<int> Age { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата заїзду")]
        [Required(ErrorMessage =
        "Потрібно заповнити поле \'Дата заїзду\'")]
        public Nullable<System.DateTime> DateArrival { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата виїзду")]
        [Required(ErrorMessage =
        "Потрібно заповнити поле \'Дата виїзду\'")]
        public Nullable<System.DateTime> DateExit { get; set; }
        [Display(Name = "Сума")]
        public Nullable<int> Sum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CPA> CPA { get; set; }
        public virtual Number Number { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SportsHall> SportsHall { get; set; }
    }
}
