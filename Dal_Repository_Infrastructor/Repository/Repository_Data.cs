using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal_Repository_Infrastructor.Repository
{
    public class Repository_Data
    {
       protected ProtectedSpace_context DbContext;
       public Repository_Data(ProtectedSpace_context context)
        {
            DbContext = context;
        }


    }
}
