using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IRepository<T>
    {
        Task<List<T>> getAllAsync();
        Task<T> getById(int id);
        Task<int> deleteAsync(int id);
        Task<int> updateAsync(T entity);
        Task<int> postAsync(T entity);




    }
}
