using AutoMapper;
using Core.models;
using Core.Resources__Dto;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace ProtectedSpace_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeStructureController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IServices_TypeStructure _services_TypeStructure;

        public TypeStructureController(IMapper mapper, IServices_TypeStructure services_TypeStructure)
        {
            _mapper = mapper;
            _services_TypeStructure = services_TypeStructure;
        }
        [HttpGet()]
        public async Task<List<TypeStructure>> GetLastMonth()//[FromQuery] string id)המידאלאוו לתז עובד רק לקריאות של כתובת...
        {
            var l = await _services_TypeStructure.getAllAsync();
            return _mapper.Map<List<TypeStructure>>(l);
            

        }
    }
}
