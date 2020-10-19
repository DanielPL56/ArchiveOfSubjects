using SubjectsDAL.Models;

namespace SubjectsDAL.Repository
{
    public class HumanRepository : BaseRepository<Human>, IRepository<Human>
    {
        public HumanRepository()
        {
            table = context.Humans;
        }
    }
}
