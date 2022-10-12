using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecole42Entity.Entity
{
    [Table("UsefulLink", Schema = "dbo")]
    public class UsefulLink : BaseEntity
    {
        public UsefulLink()
        {
            this.ProjectUsefulLinks = new HashSet<ProjectUsefulLink>();
        }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public string URL { get; set; }
        public virtual ICollection<ProjectUsefulLink> ProjectUsefulLinks { get; set; }
    }
}
