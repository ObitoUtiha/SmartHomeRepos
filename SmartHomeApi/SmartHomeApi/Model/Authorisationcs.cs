using System.ComponentModel.DataAnnotations;

namespace SmartHomeApi.Model
{
    public class Authorisationcs
    {
        [Key]
        public string? Login { get; set; }
        public string? Password { get; set; }
    }
}
