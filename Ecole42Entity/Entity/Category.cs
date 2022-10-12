using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecole42Entity.Entity
{
    [Table("Category", Schema = "dbo")]
    public class Category : BaseEntity
    {
        public Category()
        {
            this.Projects = new HashSet<Project>();
        }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
