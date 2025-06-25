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
    public class Services_Opinion : IServices_Opinion
    {
        private readonly IRepository_Opinion _repository_Opinion;
        public Services_Opinion(IRepository_Opinion repository_Opinion)
        {
            _repository_Opinion = repository_Opinion;
        }
        public Task<int> deleteAsync(int id)
        {
            //DALקריאה לפונקציית הגישה ב
            throw new NotImplementedException();
        }

        public Task<List<Opinion>> getAllAsync()
        {
            //DALקריאה לפונקציית הגישה ב
            throw new NotImplementedException();
        }

        public Task<Opinion> getById(int id)
        {
            //DALקריאה לפונקציית הגישה ב
            throw new NotImplementedException();
        }

        public Task<int> postAsync(Opinion entity)
        {
            //DALקריאה לפונקציית הגישה ב
            throw new NotImplementedException();
        }

        public Task<int> updateAsync(Opinion entity)
        {
            //DALקריאה לפונקציית הגישה ב
            throw new NotImplementedException();
        }
        //ADL פונקציות מענינות נוספות המשלבות בתוכן קריאה לפונקציות הגישה ב
    }
}
