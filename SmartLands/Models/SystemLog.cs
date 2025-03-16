using System.ComponentModel.DataAnnotations;

namespace SmartLands.Models
{
    public class SystemLog
    {
        [Key]
        [Display(Name = "Mã ghi log")]
        public int SystemLogId { get; set; }
        [Display(Name = "Thời gian")]
        public DateTime Timestamp { get; set; }
        [Display(Name = "Mô tả hành động")]
        public string Action { get; set; } // Mô tả hành động
        [Display(Name = "Người thực hiện")]
        public string User { get; set; } // Người thực hiện
    }
}
