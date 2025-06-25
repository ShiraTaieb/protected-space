using Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IServices_Address: IServices<Address>
    {
        public Task<List<Address>> getLastMonthAsync();
        public Task<List<Address>> getProtectedSpaseAsync(decimal lat, decimal lng, bool driving);
        public bool IsIsraeliIdValid(string id);
    }
}
