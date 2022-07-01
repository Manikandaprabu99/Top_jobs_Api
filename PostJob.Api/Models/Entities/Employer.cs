using System.ComponentModel.DataAnnotations;

namespace PostJob.Api.Models.Entities
{
    public class Employer
    {

        [Key]
        public string? FirstName { get; set; }
        public string? CompanyName { get; set; }

        public string? Email { get; set; }

        public string? Mobile { get; set; }

        public string? Gender { get; set; }

        public string? Pwd { get; set; }

        public DateTime MemberSince { get; set; }
    }
}
