using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanSample.Domain.Entities
{
    public class Player
    {
        public Guid Id { get; set; }

        [MaxLength(200)]
        public string Firstname { get; set; }
        [MaxLength(200)]
        public string Lastname { get; set; }
        public int TeamId { get; set; }
        public DateTime BirthDate { get; set; }
        
        [Range(0, 99)]
        public byte JerseyNumber { get; set; }
        public virtual Team Team { get; set; }
    }
}
