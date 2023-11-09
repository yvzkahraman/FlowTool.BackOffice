using Dapper;
using FlowTool.Application.Interfaces;
using FlowTool.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowTool.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IDbConnection connection;

        public ProjectRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public async Task<Project> CreateProjectAsync(Project project)
        {
            await this.connection.ExecuteAsync(sql: "insert into Projects values(@name,@edges,@nodes,@createdDate)", param: project);


            var createdProject = await this.connection.QueryFirstAsync<Project>("select Id, Name, CreatedDate from Projects order by CreatedDate desc");

            return createdProject;
        }

        public async Task<IEnumerable<Project>?> GetAllAsync()
        {
            var list = await this.connection.QueryAsync<Project>(sql: "select * from Projects order by CreatedDate desc");
            return list;
        }

        public async Task<Project?> GetByIdAsync(int id)
        {
            var project = await this.connection.QuerySingleOrDefaultAsync<Project>(sql: "select * from Projects where Id=@id", param: new { id });
            return project;
        }

        public async Task UpdateProjectAsync(Project project)
        {
            await this.connection.ExecuteAsync(sql: "update Projects Set Edges=@Edges, Nodes= @Nodes where Id = @Id", param: project);
        }

    }
}
