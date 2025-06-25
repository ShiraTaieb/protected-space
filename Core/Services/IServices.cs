using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    //פה ניצור את חתימת הפונקציות שמזמנות את הקראד הבסיסיות ללא אף שיכלול
    //DALשרק יזמן את פונקצית הגישה בפועל מה BLLגם עבור הבסיס נעבור דרך ה
    //את הפונקציות המענינות נכתוב כל אחד בממשק שלו כיון שבין ישות לישות יש שינוי בפונקצית המשוכללות יותר
    public interface IServices<T>
    {
        Task<List<T>> getAllAsync();
        Task<T> getById(int id);
        Task<int> deleteAsync(int id);
        Task<int> updateAsync(T entity);
        Task<int> postAsync(T entity);
    }
}
