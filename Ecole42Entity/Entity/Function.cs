using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecole42Entity.Entity
{
    [Table("Function", Schema = "dbo")]
    public class Function : BaseEntity
    {
        public Function()
        {
            this.ProjectFunctions = new HashSet<ProjectFunction>();
        }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ProjectFunction> ProjectFunctions { get; set; }
    }
}
