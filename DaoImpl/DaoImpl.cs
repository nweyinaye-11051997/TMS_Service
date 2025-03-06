using Microsoft.Build.Evaluation;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TaskManagementSystem.IDao;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.DaoImpl
{
    public class DaoImpl<T> : IDao<T> where T : class
    {
        private readonly DBContext _context;
        private readonly DbSet<T> _dbSet;

        public DaoImpl(DBContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<List<TaskEntity>> SearchByField(string? TaskName, string? ProjectID, int? Priority, string? Status)
        {
          
            var query = _context.tblTask.AsQueryable();

            if (!string.IsNullOrEmpty(TaskName))
                query = query.Where(p => p.TaskName.Contains(TaskName));

            if (!string.IsNullOrEmpty(ProjectID))
                query = query.Where(p => p.ProjectID.Contains(ProjectID));

            if (Priority.HasValue)
                query = query.Where(p => p.Priority == Priority);

            if (!string.IsNullOrEmpty(Status))
                query = query.Where(p => p.Status.Contains(Status));

            return await query.ToListAsync();
        }

        public async Task<List<TaskEntity>> GetAllAssignTaskAsync()
        {

            var res = await _context.tblTask
                 .Include(t => t.AssignTasks)  // Ensures EF loads related AssignTasks
                 .ToListAsync();

            return res;
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
