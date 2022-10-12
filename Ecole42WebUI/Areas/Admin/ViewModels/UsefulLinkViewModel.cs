using System;
using Ecole42Entity.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecole42WebUI.Areas.Admin.ViewModels
{
    public class UsefulLinkViewModel
    {
        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<ProjectUsefulLink> ProjectUsefulLinks { get; set; }
        public ProjectUsefulLink ProjectUsefulLink { get; set; }
    }
}
