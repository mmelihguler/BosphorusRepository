using Entities.Model;

namespace Entities.Repository
{
    public class RepoProject : Repository<Project>
    {
        public RepoProject(DataContext dataContext) : base(dataContext)
        {
        }
    }
}