using Core.models;
using Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal_Repository_Infrastructor.Repository
{
    public class Repository_Opinion : Repository_Data, IRepository_Opinion
    {
        public Repository_Opinion(ProtectedSpace_context context):base(context) { }
        public Task<List<Opinion>> getAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Opinion> getById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<int> deleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> postAsync(Opinion entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> updateAsync(Opinion entity)
        {
            throw new NotImplementedException();
        }
    }
}
