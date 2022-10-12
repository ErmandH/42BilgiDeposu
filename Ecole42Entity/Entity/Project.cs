using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecole42Entity.Entity
{
    [Table("Project", Schema = "dbo")]
    public class Project : BaseEntity
    {
        public Project()
        {
            this.ProjectFunctions = new HashSet<ProjectFunction>();
            this.ProjectUsefulLinks = new HashSet<ProjectUsefulLink>();
        }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public Guid CategoryID { get; set; }
        public Category Category { get; set; }
        public virtual ICollection<ProjectFunction> ProjectFunctions { get; set; }
        public virtual ICollection<ProjectUsefulLink> ProjectUsefulLinks { get; set; }
    }
}
