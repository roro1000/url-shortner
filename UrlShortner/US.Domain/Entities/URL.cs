using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class URL
    {
        public int ID { get; set; }

        [Required]
        public string LongValue { get; set; }

        [Required]
        public string ShortValue { get; set; }
    }
}
