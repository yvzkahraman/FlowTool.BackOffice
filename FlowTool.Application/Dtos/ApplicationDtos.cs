using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowTool.Application.Dtos
{
   public record CreateProjectResponse(int Id, string Name, DateTime CreatedDate);

    public record ProjectListResponse(int Id, string Name);

    public record ProjectResponse(int Id, string Name, dynamic? Edges, dynamic? Nodes);

}
