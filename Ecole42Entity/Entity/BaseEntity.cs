using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecole42Entity.Entity
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            this.ID = Guid.NewGuid();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastDateTime { get; set; }
        public bool DeletionStatus { get; set; }
    }
}
