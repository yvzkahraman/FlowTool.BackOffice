using FlowTool.Application.Dtos;
using FlowTool.Application.Extensions;
using FlowTool.Application.Interfaces;
using FlowTool.Application.Requests;
using FlowTool.Application.Validators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowTool.Application.Handlers
{
    public class CreateProjectRequestHandler : IRequestHandler<CreateProjectRequest, Result<CreateProjectResponse>>
    {
        private readonly IProjectRepository repository;

        public CreateProjectRequestHandler(IProjectRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<CreateProjectResponse>> Handle(CreateProjectRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateProjectRequestValidator();

            var validationResult = validator.Validate(request);
            if (validationResult.IsValid)
            {
                var createdProject = await this.repository.CreateProjectAsync(request.ToMap());

                var result = createdProject.ToMap();


                return new Result<CreateProjectResponse>(result, true, null, null);

            }
            else
            {
                return new Result<CreateProjectResponse>(null, false, null, validationResult.Errors.ToMap());
            }
        
        }
    }
}
