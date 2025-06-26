using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core.Resources__Dto
{
    public class AddressResources
    {
        public int Id { get; set; }
        //ניתן להוסיף שם מבנה ועוד פרטים.. 
        public int TypeStructureId { get; set; }//מפתח זר לטבלת סוגי מבנים
       public string? TypeStructureName { get; set; }
        public bool Open { get; set; }
        public string ContactPerson { get; set; }//איש ליצירת קשר
        public string PhoneNumber { get; set; }
        public string Capacity { get; set; }//קיבולת
        public int CurrentNumberOfPeople { get; set; }//כמות אנשים עכשווית
        public DateTime Date { get; set; }//תאריך הוספת הכתובת

        // שדות מיקום                              
        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
}
