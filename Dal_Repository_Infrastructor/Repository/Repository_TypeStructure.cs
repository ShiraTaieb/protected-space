using Core.models;
using Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal_Repository_Infrastructor.Repository
{
    public class Repository_TypeStructure : Repository_Data, IRepository_TypeStructure
    {
        public Repository_TypeStructure(ProtectedSpace_context context):base(context) { }
        public Task<List<TypeStructure>> getAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TypeStructure> getById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<int> deleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> postAsync(TypeStructure entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> updateAsync(TypeStructure entity)
        {
            throw new NotImplementedException();
        }
    }
}
