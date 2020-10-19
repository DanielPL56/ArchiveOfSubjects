using SubjectsDAL.Models;

namespace SubjectsDAL.Repository
{
    public class AndroidRepository: BaseRepository<Android>, IRepository<Android>
    {
        public AndroidRepository()
        {
            table = context.Androids;
        }
    }
}
