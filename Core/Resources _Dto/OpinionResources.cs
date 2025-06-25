using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.models.Opinion;

namespace Core.Resources__Dto
{
    public class OpinionResources
    {
        public int Id { get; set; }
        public int AddressId { get; set; }//מפתח זר לטבלת כתובות
        public TypeOpinion TOpinion { get; set; }//ENUMסוג חוות הדעת מ
        public string TxtOpinion { get; set; }//טקסט חוות הדעת
        public string img {  get; set; }
        
    }
}
