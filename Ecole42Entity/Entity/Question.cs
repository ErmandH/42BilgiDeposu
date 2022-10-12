using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecole42Entity.Entity
{
    [Table("Question", Schema = "dbo")]
    public class Question : BaseEntity
    {
        public Question() 
        {
            this.AnswerQuestions = new HashSet<AnswerQuestion>();
        }
        [Required]
        [MaxLength(100)]
		public string Title { get; set; }
        [Required]
        public string Description { get; set; }
		public Guid UserID { get; set; }
		public Guid AdminID { get; set; }
		public User User { get; set; }
		public Admin Admin { get; set; }
        public virtual ICollection<AnswerQuestion> AnswerQuestions { get; set; }
    }
}
