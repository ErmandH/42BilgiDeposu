using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecole42Entity.Entity
{
    [Table("Article", Schema = "dbo")]
    public class Article : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string AuthorName { get; set; }
        [Required]
        public string AuthorSurname { get; set; }
        public Guid? AdminID { get; set; }
        public virtual Admin Admin { get; set; }
        public Guid? UserID { get; set; }
        public virtual User User { get; set; }
    }
}
