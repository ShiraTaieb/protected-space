using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.models
{
    public class TypeStructure
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ConstructionYear { get; set; }//שנת בניה
        public Level level { get; set; }// ENUM-רמה מה


        public enum Level
        {
            Public_shelter=0,//מקלט ציבורי
            shelter=1,//מקלט
            protected_public_area=2,//שטח ציבורי מוגן
            dimension=3,//ממד
            stairwell=4//חדר מדרגות
        }
    }

}
