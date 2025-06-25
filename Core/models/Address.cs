using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.models
{
    public class Address
    {
        public int Id { get; set; }
        public int TypeStructureId { get; set; }
        public TypeStructure TypeStructure { get; set; }//הכלה
        public bool Open { get; set; }
        public string ContactPerson { get; set; }//איש ליצירת קשר
        public string PhoneNumber { get; set; }
        //sms
        public string Capacity { get; set; }//קיבולת
        public int CurrentNumberOfPeople { get; set; }//כמות אנשים עכשווית
        public DateTime Date { get; set; }//תאריך הוספת הכתובת

        // שדות מיקום                              
        [Column(TypeName = "decimal(18,12)")]
        public decimal Latitude { get; set; }

        [Column(TypeName = "decimal(18,12)")]
        public decimal Longitude { get; set; }
    }
}
