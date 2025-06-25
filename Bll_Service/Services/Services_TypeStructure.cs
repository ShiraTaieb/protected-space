using Core.models;
using Core.Repository;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll_Service.Services
{
    public class Services_TypeStructure : IServices_TypeStructure
    {
        private readonly IRepository_TypeStructure _repository_TypeStructure;
        public Services_TypeStructure(IRepository_TypeStructure repository_TypeStructure) 
        { 
            _repository_TypeStructure = repository_TypeStructure;
        }
        public Task<int> deleteAsync(int id)
        {
            //DALקריאה לפונקציית הגישה ב
            throw new NotImplementedException();
        }

        public Task<List<TypeStructure>> getAllAsync()
        {
            //DALקריאה לפונקציית הגישה ב
            throw new NotImplementedException();
        }

        public Task<TypeStructure> getById(int id)
        {
            //DALקריאה לפונקציית הגישה ב
            throw new NotImplementedException();
        }

        public Task<int> postAsync(TypeStructure entity)
        {
            //DALקריאה לפונקציית הגישה ב
            throw new NotImplementedException();
        }

        public Task<int> updateAsync(TypeStructure entity)
        {
            //DALקריאה לפונקציית הגישה ב
            throw new NotImplementedException();
        }
        //ADL פונקציות מענינות נוספות המשלבות בתוכן קריאה לפונקציות הגישה ב
    }
}
