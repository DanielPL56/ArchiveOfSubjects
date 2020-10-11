using SubjectsDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubjectsDAL.Repos
{
    public class AndroidRepo: BaseRepo<Android>, IRepo<Android>
    {
        public AndroidRepo()
        {
            table = context.Androids;
        }
    }
}
