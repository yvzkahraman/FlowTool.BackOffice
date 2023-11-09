using FlowTool.Application.Dtos;
using FlowTool.Application.Interfaces;
using FlowTool.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FlowTool.Application.Handlers
{
    public class GetProjectByIdRequestHandler : IRequestHandler<GetProjectByIdRequest, Result<ProjectResponse?>>
    {
        private readonly IProjectRepository projectRepository;

        public GetProjectByIdRequestHandler(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public async Task<Result<ProjectResponse?>> Handle(GetProjectByIdRequest request, CancellationToken cancellationToken)
        {

            dynamic? edges = null;
            dynamic? nodes = null;

            var result = await this.projectRepository.GetByIdAsync(request.Id);
            if (result != null && result.Edges != null && result.Nodes != null)
            {
                edges = JsonSerializer.Deserialize<dynamic?>(result.Edges);
                nodes = JsonSerializer.Deserialize<dynamic?>(result.Nodes);
            }

            return new Result<ProjectResponse?>(new ProjectResponse(result.Id, result.Name, edges, nodes), true, null, null);
        }
    }
}
