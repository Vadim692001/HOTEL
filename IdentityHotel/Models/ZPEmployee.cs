
namespace IdentityHotel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ZPEmployee
    {
        public int idCost { get; set; }
        [Display(Name = "Прізвище")]
        public Nullable<int> SornameEmployee { get; set; }
        [Display(Name = "Ім'я")]
        public Nullable<int> NameEmployee { get; set; }
        [Display(Name = "Тариф")]
        [Range(1, 10)]
        [Required(ErrorMessage =
       "Потрібно заповнити поле \'Тариф  від 1 до 10 \'")]
        public Nullable<int> Tariff { get; set; }
        [Display(Name = "Відпрацювані години")]
        [Range(0, 320)]
        [Required(ErrorMessage =
       "Потрібно заповнити поле \'Відпрацювані години від 0 до 320 \'")]
        public Nullable<int> TimeWorked { get; set; }
        [Display(Name = "Сума")]
        public Nullable<int> Sum { get; set; }
        [Display(Name = "Заробітня карта")]
        public Nullable<int> CardZP { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Employee Employee1 { get; set; }
        public virtual Employee Employee2 { get; set; }
    }
}
