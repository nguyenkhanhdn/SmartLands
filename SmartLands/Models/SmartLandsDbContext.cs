using Microsoft.EntityFrameworkCore;

namespace SmartLands.Models
{
    public class LandslideDbContext : DbContext
    {        
        public DbSet<Area> Areas { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<SensorData> SensorDatas { get; set; }
        public DbSet<LandsEvent> LandsEvents { get; set; }
        public DbSet<SystemLog> SystemLogs { get; set; }
        public LandslideDbContext(DbContextOptions<LandslideDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Sensor>()
                .HasOne(s => s.Area)
                .WithMany(a => a.Sensors)
                .HasForeignKey(s => s.AreaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SensorData>()
                .HasOne(sd => sd.Sensor)
                .WithMany(s => s.SensorReadings)
                .HasForeignKey(sd => sd.SensorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LandsEvent>()
                .HasOne(le => le.Area)
                .WithMany()
                .HasForeignKey(le => le.AreaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
