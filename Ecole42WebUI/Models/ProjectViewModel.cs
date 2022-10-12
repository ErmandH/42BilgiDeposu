using System;
using Ecole42Entity.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecole42WebUI.Models
{
    public class ProjectViewModel
    {
        public Project Project { get; set; }
        public IEnumerable<ProjectFunction> ProjectFunctions { get; set; }
        public IEnumerable<ProjectUsefulLink> ProjectUsefulLinks { get; set; }
    }
}
