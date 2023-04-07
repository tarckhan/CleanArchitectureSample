using System;
using System.ComponentModel.DataAnnotations;

namespace CleanSample.Application.Models.DTOs
{
    public class PlayerDto
    {
        public Guid Id { get; set; }

        [MaxLength(200)]
        public string Firstname { get; set; }
        [MaxLength(200)]
        public string Lastname { get; set; }
        public Guid TeamId { get; set; }
        public DateTime BirthDate { get; set; }

        [Range(0, 99)]
        public byte JerseyNumber { get; set; }

        [MaxLength(400)]
        public string AdditionalInfo { get; set; }
    }
}
