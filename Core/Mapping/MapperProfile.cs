using AutoMapper;
using Core.models;
using Core.Resources__Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping
{
    public class MapperProfile:Profile
    {
       public MapperProfile() 
        {
            //1
            CreateMap<TypeStructure, TypeStructureResources>().ReverseMap();
            //2
            //מהמסד החוצה
            //DEST=יעד-TypeStructureResources
            //origin=מקור-TypeStructure
            //ממירים ממקור ליעד..
            CreateMap<Opinion, OpinionResources>();
            /* CreateMap<Opinion, OpinionResources>().ForMember(dest => dest.AddressId
             , origin => origin.MapFrom(o => o.Address.Id));*/
            //מבחוץ למסד
            //כרגע מתעלמים ADDRESSומהאובייקט OPINIONRESOURSES של  ADDRESSID שאליו יכנס במיפוי האוטומטי הערך מ ADDRESSID OPINION-יש לי בחוות דעת  
            CreateMap<OpinionResources, Opinion>().ForMember(dest => dest.Address, origin => origin.Ignore());
            //3
            //מהמסד החוצה
            CreateMap<Address, AddressResources>();
            //מבחוץ למסד
            CreateMap<AddressResources,Address>().ForMember(dest=>dest.TypeStructure, origin => origin.Ignore());
        }

    }
}
