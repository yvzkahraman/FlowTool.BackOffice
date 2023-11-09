using FlowTool.Application.Interfaces;
using FlowTool.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowTool.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IDbConnection>(sp =>
            {
                return new SqlConnection(configuration.GetConnectionString("Local"));
            });

            services.AddScoped<IProjectRepository, ProjectRepository>();
        }
    }
}
