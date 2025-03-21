﻿using TaskManagementSystem.Models;

namespace TaskManagementSystem.ServiceInterface
{
    public interface IAssignTaskService : IService<AssignTaskEntity>
    {
        Task UpdateAssignTaskAsync(AssignTaskEntity updatedEntity);
        Task AssignTaskAsync(AssignTaskEntity task);
        Task AddAssignTaskAsync(AssignTaskEntity entity, string taskID, string memberID);
    }
}
