using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecole42Entity.Entity;

namespace Ecole42WebUI.Areas.Admin.ViewModels
{
    public class ProjectViewModel
    {
        public Project Project { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
