using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecole42Entity.Entity
{
    [Table("ProjectFunction", Schema = "dbo")]
    public class ProjectFunction : BaseEntity
    {
        public Guid ProjectID { get; set; }
        public Project Project { get; set; }
        public Guid FunctionID { get; set; }
        public Function Function { get; set; }
    }
}
