using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanSample.Domain.Entities
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public int TeamId { get; set; }
        public DateTime BirthDate { get; set; }
        public byte JerseyNumber { get; set; }
    }
}
