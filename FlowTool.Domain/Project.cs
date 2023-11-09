﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowTool.Domain
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string? Edges { get; set; }

        public string? Nodes { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
