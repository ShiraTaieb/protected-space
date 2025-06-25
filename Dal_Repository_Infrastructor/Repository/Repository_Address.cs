using Core.models;
using Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal_Repository_Infrastructor.Repository
{
    public class Repository_Address : Repository_Data, IRepository_Address
    {
        public  Repository_Address(ProtectedSpace_context context) :base(context){ }
        public async Task<List<Address>> getAllAsync()
        {
            return await DbContext.Address.ToListAsync();
        }

        public Task<Address> getById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> deleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        
        public async Task<int> postAsync(Address entity)
        {
            if (entity != null)
            {
               await DbContext.Address.AddAsync(entity);
                return DbContext.SaveChanges();
            }
            return -1;
        }

        public Task<int> updateAsync(Address entity)
        {
            throw new NotImplementedException();
        }
    }
}
