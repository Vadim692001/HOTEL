
namespace IdentityHotel.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cost
    {
        public int idCost { get; set; }
        public string Cost1 { get; set; }
        public Nullable<decimal> Sum { get; set; }
        public Nullable<int> TranslationAccount { get; set; }
    }
}
