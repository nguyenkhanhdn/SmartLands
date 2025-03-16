using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartLands.Models
{
    public class SensorData
    {
        [Key]
        public int SensorDataId { get; set; }

        [Required]
        [Display(Name = "Mã thiết bị")]
        public int SensorId { get; set; }

        [ForeignKey("SensorId")]
        public Sensor Sensor { get; set; }

        [Required]
        [Display(Name = "Thời gian")]
        public DateTime Timestamp { get; set; }
        [Display(Name = "Giá trị đo")]

        public double Value { get; set; } // Ví dụ: độ rung, độ ẩm đất, gia tốc
        [Display(Name = "Đơn vị đo")]
        public string Unit { get; set; } // Đơn vị đo lường
    }
}
