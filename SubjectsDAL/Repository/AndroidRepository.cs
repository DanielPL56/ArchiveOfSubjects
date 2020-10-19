using SubjectsDAL.Models;

namespace SubjectsDAL.Repository
{
    public class AndroidRepository: BaseRepository<Android>, IRepo<Android>
    {
        public AndroidRepository()
        {
            table = context.Androids;
        }
    }
}
