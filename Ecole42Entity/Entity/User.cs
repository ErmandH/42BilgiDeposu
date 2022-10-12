using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecole42Entity.Entity
{
    [Table("User", Schema = "dbo")]
    public class User : BaseEntity
    {
        public User()
        {
            this.Articles = new HashSet<Article>();
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public int intraID { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
