using FlowTool.Application.Dtos;
using FlowTool.Application.Extensions;
using FlowTool.Application.Interfaces;
using FlowTool.Application.Requests;
using FlowTool.Application.Validators;
using MediatR;
using System.Text.Json;

namespace FlowTool.Application.Handlers
{
    public class UpdateProjectRequestHandler : IRequestHandler<UpdateProjectRequest, Result<NoContent>>
    {
        private readonly IProjectRepository projectRepository;

        public UpdateProjectRequestHandler(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public async Task<Result<NoContent>> Handle(UpdateProjectRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateProjectRequestValidator();
            var validationResult =  validator.Validate(request);
            if(validationResult.IsValid)
            {
                
                await this.projectRepository.UpdateProjectAsync(request.ToMap());

                return new Result<NoContent>(new NoContent(), true, null, null);
            }
            else
            {
                return new Result<NoContent>(null, false, null, validationResult.Errors.ToMap());
            }
        }
    }
}
