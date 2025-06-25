using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.models
{
    public class Opinion
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public Address Address{ get; set; }//הכלה
        public TypeOpinion TOpinion { get; set; }//ENUMסוג חוות הדעת מ
        public string TxtOpinion { get; set; }//טקסט חוות הדעת
        public string img { get; set; }
        public enum TypeOpinion
        {
            Good=0,
            Nice=1,
            Bad=2
        }
    }
}
