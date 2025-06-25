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
    public class AddressController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IServices_Address _services_Address;

        public AddressController(IMapper mapper, IServices_Address services_Address)
        {
            _mapper = mapper;
            _services_Address = services_Address;
        }
        //פונקציה להוספת נקודה חדשה 
        //"פרסום נקודה חדשה"
        [HttpPost]
        public async Task<int> Post(AddressResources a, [FromQuery] string id)
        {
            var map_a = _mapper.Map<Address>(a);
            return await _services_Address.postAsync(map_a);
        }
        [HttpGet("LastMonth")]
        public async Task<List<AddressResources>> GetLastMonth([FromQuery] string id)
        {
            var l = await _services_Address.getLastMonthAsync();
            return _mapper.Map<List<AddressResources>>(l);

        }
        [HttpGet("ProtectedSpace/{lat}/{lng}")]
        public async Task<List<AddressResources>> GetProtectedSpase(decimal lat, decimal lng, bool driving, [FromQuery] string id)
        {
            var l=await _services_Address.getProtectedSpaseAsync(lat,lng,driving);
            return _mapper.Map<List<AddressResources>>(l);
        }
    }
}

