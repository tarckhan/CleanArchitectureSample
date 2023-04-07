using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanSample.Domain.Entities
{
    public class Division
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }
        
        [MaxLength(5)]
        public string DivisionCode { get; set; }
        public virtual ICollection<Team> Teams { get; set; }

    }
}
