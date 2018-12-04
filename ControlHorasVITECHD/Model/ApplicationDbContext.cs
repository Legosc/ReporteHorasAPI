using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ControlHorasVITECHD.Model
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(p => new { p.UserId, p.LoginProvider, p.ProviderKey });
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(p => new { p.UserId, p.RoleId });
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(p => new { p.UserId, p.LoginProvider, p.Name });
            modelBuilder.Entity<IdentityUserClaim<string>>().HasKey(p=>p.Id);
            


            modelBuilder.Entity<Hours>().HasOne(ht => ht.Tasks).WithMany(th => th.Hours).HasForeignKey(fk => fk.IdTask);
            modelBuilder.Entity<Hours>().HasOne(hu => hu.Users).WithMany(th => th.Hours).HasForeignKey(fk => fk.IdUser);
            modelBuilder.Entity<Tasks>().HasOne(tp => tp.Proyects).WithMany(pt => pt.Tasks).HasForeignKey(fk =>fk.IdProyect);
            modelBuilder.Entity<Tasks>().HasOne(tu => tu.Users).WithMany(ut => ut.Tasks).HasForeignKey(fk=>fk.IdUser);
            modelBuilder.Entity<Proyects>().HasOne(pc => pc.Clients).WithMany(cp => cp.Proyects).HasForeignKey(fk => fk.IdClient);

        }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Hours> Hours { get; set; }
        public DbSet<Proyects> Proyects { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
    }
}

