using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class RoomContext : DbContext
    {
        public RoomContext(DbContextOptions<RoomContext> options) : base(options)
        {
        }

        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomAmenities> RoomAmenities { get; set; }
        public virtual DbSet<RoomAmenitiesMapping> RoomAmenitiesMappings { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Ward> Wards { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Chat> Chats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomAmenitiesMapping>()
                .HasKey(c => new { c.roomID, c.amenitiesID });

            modelBuilder.Entity<Review>()
                .HasKey(c => new { c.roomID, c.userID });

            // Cấu hình mối quan hệ giữa Rooms và Users
            modelBuilder.Entity<Room>()
                .HasOne(r => r.User) // Room có một User
                .WithMany(u => u.Rooms) // User có nhiều Rooms
                .HasForeignKey(r => r.userID) // Khóa ngoại là userID
                .OnDelete(DeleteBehavior.NoAction); // Thiết lập hành động xóa là NoAction

            // Cấu hình mối quan hệ giữa Rooms và Wards
            modelBuilder.Entity<Room>()
                .HasOne(r => r.Ward) // Room có một Ward
                .WithMany(w => w.Rooms) // Ward có nhiều Rooms
                .HasForeignKey(r => r.wardID) // Khóa ngoại là wardID
                .OnDelete(DeleteBehavior.NoAction); // Thiết lập hành động xóa là NoAction
        }

    }
}
