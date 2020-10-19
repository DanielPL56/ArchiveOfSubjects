using SubjectsDAL.Models;

namespace SubjectsDAL.Repository
{
    public class HumanRepository : BaseRepository<Human>, IRepo<Human>
    {
        public HumanRepository()
        {
            table = context.Humans;
        }
    }
}
