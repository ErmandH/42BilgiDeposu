using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecole42Entity.Entity
{
    [Table("Answer", Schema = "dbo")]
    public class Answer : BaseEntity
    {
        public Answer() 
        {
            this.AnswerQuestions = new HashSet<AnswerQuestion>();
        }
        [Required]
        public string Description { get; set; }
		public Guid UserID { get; set; }
		public Guid AdminID { get; set; }
		public User User { get; set; }
		public Admin Admin { get; set; }
        public virtual ICollection<AnswerQuestion> AnswerQuestions { get; set; }
    }
}
