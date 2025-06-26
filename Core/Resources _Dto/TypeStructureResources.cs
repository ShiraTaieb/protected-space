using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.models.TypeStructure;

namespace Core.Resources__Dto
{
    public class TypeStructureResources
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ConstructionYear { get; set; }//שנת בניה
        public Level level { get; set; }// ENUM-רמה מה


    }
}
