using FlowTool.Application.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowTool.Application.Validators
{
    public class UpdateProjectRequestValidator : AbstractValidator<UpdateProjectRequest>
    {
        public UpdateProjectRequestValidator()
        {
            this.RuleFor(x=>x.Edges).NotEmpty();
            this.RuleFor(x=>x.Nodes).NotEmpty();
            this.RuleFor(x=>x.Id).NotEmpty();
         
        }
    }
}
