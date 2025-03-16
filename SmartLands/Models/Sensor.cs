using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartLands.Models
{
    public class Sensor
    {
        [Key]
        public int SensorId { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name="Thiết bị cảm biến")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Khu vực giám sát")]
        public int AreaId { get; set; }

        [ForeignKey("AreaId")]
        public Area Area { get; set; }

        public ICollection<SensorData> SensorReadings { get; set; }
    }
}
