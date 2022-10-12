using Ecole42Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecole42WebUI.Areas.Admin.ViewModels
{
    public class FunctionViewModel
    {
        public IEnumerable<Project> Projects { get; set; }
        public ProjectFunction ProjectFunction { get; set; }
    }
}
