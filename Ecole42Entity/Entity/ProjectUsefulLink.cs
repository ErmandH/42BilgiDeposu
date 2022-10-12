using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecole42Entity.Entity
{
    [Table("ProjectUsefulLink", Schema = "dbo")]
    public class ProjectUsefulLink : BaseEntity
    {
        public Guid ProjectID { get; set; }
        public Project Project { get; set; }
        public Guid UsefulLinkID { get; set; }
        public UsefulLink UsefulLink { get; set; }
    }
}
