using FlowTool.Application.Dtos;
using FlowTool.Application.Requests;
using FlowTool.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FlowTool.Application.Extensions
{
    public static class MappingExtensions
    {
        public static Project ToMap(this CreateProjectRequest request)
        {
            return new Project
            {
                CreatedDate = DateTime.Now,
                Edges = null,
                Name = request.Name,
                Nodes = null
            };
        }

        public static CreateProjectResponse ToMap(this Project project)
        {
            return new CreateProjectResponse
            (project.Id, project.Name, project.CreatedDate);
        }

        public static Project ToMap(this UpdateProjectRequest request)
        {
            var serializeEdges = JsonSerializer.Serialize(request.Edges);
            var serializeNodes = JsonSerializer.Serialize(request.Nodes);
            return new Project
            {
                Edges = serializeEdges,
                Id = request.Id,
                Nodes = serializeNodes,
            };
        }
    }
}
