using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowTool.Application.Dtos
{
    public record Result<T>(T? Data, bool IsSuccess, string? Message, List<ErrorMessage>? Messages);

    public record ErrorMessage(string propertyName, string errorMessage);

    public record NoContent();

}
