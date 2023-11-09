using FlowTool.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowTool.Application.Interfaces
{
    public interface IProjectRepository
    {
        Task<Project> CreateProjectAsync(Project project);

        Task UpdateProjectAsync(Project project);

        Task<IEnumerable<Project>?> GetAllAsync();

        Task<Project?> GetByIdAsync(int id);  
    }
}
