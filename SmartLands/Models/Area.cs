using System.ComponentModel.DataAnnotations;

namespace SmartLands.Models
{
    public class Area
    {
        [Key]
        public int AreaId { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Khu vực giám sát")]
        public string Name { get; set; }
        [Display(Name = "Vị trí")]
        public string Location { get; set; }

        public ICollection<Sensor> Sensors { get; set; }
    }
}
