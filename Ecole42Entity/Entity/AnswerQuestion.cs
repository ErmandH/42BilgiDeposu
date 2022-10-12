using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecole42Entity.Entity
{
    [Table("AnswerQuestion", Schema = "dbo")]
    public class AnswerQuestion : BaseEntity
    {
		public Guid? AnswerID { get; set; }
		public Guid? QuestionID { get; set; }
		public virtual Answer Answer { get; set; }
		public virtual Question Question { get; set; }
        
    }
}
