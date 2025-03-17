using Microsoft.Build.Evaluation;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;
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
                 .Include(t => t.AssignTasks) 
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
        public async Task AddAssignTaskAsync(T entity,string taskID,string memberID)
        {
        
         
            var userAlreadyAssigned = await _context.tblAssignTask
       .AnyAsync(at => at.TaskID == taskID && at.MemberID == memberID);

            if (userAlreadyAssigned)
            {
                throw new InvalidOperationException("Member is already assigned to this task.");
            }

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
        public async Task UpdateAssignTaskAsync(AssignTaskEntity updatedEntity)
        {
            try
            {
                var existingEntity = await _context.tblAssignTask.FindAsync(updatedEntity.Id);

                if (existingEntity == null)
                {
                    throw new InvalidOperationException("The record has been deleted by another user.");
                }
                var userAlreadyAssigned = await _context.tblAssignTask
                   .AnyAsync(at => at.TaskID == updatedEntity.TaskID && at.MemberID == updatedEntity.MemberID && at.Id != updatedEntity.Id);

                if (userAlreadyAssigned)
                {
                    throw new InvalidOperationException("Member is already assigned to this task.");
                }

                _context.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                foreach (var entry in ex.Entries)
                {
                    if (entry.Entity is AssignTaskEntity)
                    {
                        var databaseValues = await entry.GetDatabaseValuesAsync();
                        if (databaseValues == null)
                        {
                            throw new InvalidOperationException("The record was deleted by another user.");
                        }
                        else
                        {
                            Console.WriteLine("The record has been modified by another user. Handle merge conflict.");
                            entry.OriginalValues.SetValues(databaseValues); // Reset to DB values
                            await _context.SaveChangesAsync();  // Save again after conflict resolution
                        }
                    }
                }
            }
        }

        public Task<CountModel> GetTotalCount()
        {
           
                var taskCount = _context.tblTask.Count();
                var progressCount = _context.tblTask.Count(t => t.Status == "Progress");
                var completeCount = _context.tblTask.Count(t => t.Status == "Complete");
                var notStartCount = _context.tblTask.Count(t => t.Status == "Not Start");
                var projectCount = _context.tblProject.Count(); // Static value
              
            
            
            var countModel = new CountModel
                {
                    completeCount = completeCount,
                    projectCount = projectCount,
                    progressCount = progressCount,
                    taskCount = taskCount,
                    notstartCount = notStartCount
                };

                return Task.FromResult(countModel); // Fixes the async return issue
            
        }
    }
}
