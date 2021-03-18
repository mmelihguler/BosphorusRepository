using Entities.Model;

namespace Entities.Repository
{
    public class RepoInvestor : Repository<Investor>, IRepoInvestor
    {
        public RepoInvestor(DataContext dataContext) : base(dataContext)
        {
        }
    }
}