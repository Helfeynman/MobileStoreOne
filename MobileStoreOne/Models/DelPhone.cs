using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStoreOne.Models
{
    public class DelPhone
    {
        public int PhoneId { get; set; } // ссылка на связанную модель Phone
        public Phone Phone { get; set; }
    }
}
