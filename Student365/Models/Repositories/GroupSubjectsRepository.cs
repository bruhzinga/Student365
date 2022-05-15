using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;

namespace Student365.Models.Repositories
{
    public class GroupSubjectsRepository
    {
        private DbContext _context = new DataBaseContext();
        private DbSet<GroupSubject> _dbSet;

        public GroupSubjectsRepository()
        {
            _dbSet = _context.Set<GroupSubject>();
        }

        public ObservableCollection<string> GetAllSubjectsNamesByGroupId(int groupId)
        {
            return new ObservableCollection<string>(_dbSet.Where(x => x.Group == groupId).Select(x => x.Subject));
        }
    }
}