using SubjectsDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubjectsDAL.Repos
{
    public class HumanRepo : BaseRepo<Human>, IRepo<Human>
    {
        public HumanRepo()
        {
            table = context.Humans;
        }
    }
}
