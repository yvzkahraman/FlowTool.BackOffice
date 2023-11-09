using FlowTool.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowTool.Application.Requests
{
    public record CreateProjectRequest(string Name) : IRequest<Result<CreateProjectResponse>>;

    public record UpdateProjectRequest(int Id, dynamic Edges, dynamic Nodes): IRequest<Result<NoContent>>;

    public record GetListProjectRequest(): IRequest<Result<IEnumerable<ProjectListResponse>?>>;

    public record GetProjectByIdRequest(int Id):IRequest<Result<ProjectResponse?>>;
}
