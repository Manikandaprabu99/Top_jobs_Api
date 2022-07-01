using System.ComponentModel.DataAnnotations;

namespace PostJob.Api.Models.Entities
{
    public class Admin
    {
        [Key]
        public string? Email { get; set; }

        public string? Pwd { get; set; }

        public DateTime AdminSince { get; set; }
    }
}
