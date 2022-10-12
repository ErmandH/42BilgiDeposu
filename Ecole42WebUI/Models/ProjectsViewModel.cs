using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecole42Entity.Entity;


namespace Ecole42WebUI.Models
{
    public class ProjectsViewModel
    {
        public IEnumerable<Project> FirstCircle { get; set; }
        public IEnumerable<Project> SecondCircle { get; set; }
        public IEnumerable<Project> ThirdCircle { get; set; }
        public IEnumerable<Project> FourthCircle { get; set; }
        public IEnumerable<Project> FifthCircle { get; set; }
        public IEnumerable<Project> SixthCircle { get; set; }
    }
}
