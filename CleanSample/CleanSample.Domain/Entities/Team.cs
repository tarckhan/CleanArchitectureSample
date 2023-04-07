using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanSample.Domain.Entities
{
    public class Team
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid DivisionId { get; set; }
        public string AdditionalInfo { get; set; }
    }
}
