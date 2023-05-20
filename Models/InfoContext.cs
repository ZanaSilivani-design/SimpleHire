using Microsoft.EntityFrameworkCore;

namespace SimpleHire.Models
{
    public class InfoContext : DbContext
    {
        public InfoContext(DbContextOptions<InfoContext> options)
            :base(options)
        { }

        public DbSet<Info> Information { get; set; }
        public DbSet<Job> Jobs { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Job>().HasData(
                new Job { JobId = "Dev", Name = "Software developers" },
                new Job { JobId = "Law", Name = "Lawyer" },
                new Job { JobId = "Nur", Name = "Nurse" },
                new Job { JobId = "Mar", Name = "Marketing" },
                new Job { JobId = "Mec", Name = "Mechanic" },
                new Job { JobId = "Ele", Name = "Electrician" },
                new Job { JobId = "Eng", Name = "Engineering" },
                new Job { JobId = "Tec", Name = "Teacher" }
                ) ;
            modelBuilder.Entity<Info>().HasData(
                new Info { InfoId = 1, Name= "Zana Silivani",YearExp = 5, Email= "ZanaSilivani@gmail.com", Phone="615-693-7766",Major= "Information System", JobId = "Dev" },
                new Info { InfoId = 2, Name = "Karen Smith", YearExp = 10, Email = "KarenSmith@gmail.com", Phone = "615-693-7766", Major = "Nursing", JobId = "Nur" },
                new Info { InfoId = 3, Name = "Osema Falah", YearExp = 5, Email = "OsemaFalah@gmail.com", Phone = "615-693-7766", Major = "Information System", JobId = "Mar" }
                );
        }
    }
}
