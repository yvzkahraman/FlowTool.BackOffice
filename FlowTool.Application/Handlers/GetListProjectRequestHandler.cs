using FlowTool.Application.Dtos;
using FlowTool.Application.Interfaces;
using FlowTool.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowTool.Application.Handlers
{
    public class GetListProjectRequestHandler : IRequestHandler<GetListProjectRequest, Result<IEnumerable<ProjectListResponse>?>>
    {
        private readonly IProjectRepository repository;

        public GetListProjectRequestHandler(IProjectRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<IEnumerable<ProjectListResponse>?>> Handle(GetListProjectRequest request, CancellationToken cancellationToken)
        {
            var list = (await this.repository.GetAllAsync()).Select(x=> new ProjectListResponse(x.Id,x.Name));
            return new Result<IEnumerable<ProjectListResponse>?>(list, true, null, null);
        }
    }
}
