using System.ComponentModel.DataAnnotations;

namespace Azuredotnetblobproject.Models
{
    public class Container
    {
        [Required]
        public string Name { get; set; }
    }
}
