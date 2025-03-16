using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SmartLands.Models
{
    public class LandsEvent
    {
        [Key]
        [Display(Name = "Mã sự kiện")]
        public int LandsEventId { get; set; }

        [Required]
        [Display(Name="Khu vực xảy ra")]
        public int AreaId { get; set; }

        [ForeignKey("AreaId")]
        public Area Area { get; set; }
        [Display(Name ="Vị trí xảy ra")]
        public DateTime OccurredAt { get; set; }
        [Display(Name ="Mô tả")]
        public string Description { get; set; }
    }
}
