
using MYYHospital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace MYYHospital.Db
{
    public class AppContexts:DbContext
    {
        public AppContexts(DbContextOptions<AppContexts>options):base(options) { }
        public DbSet<Doctor> doctors { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Appointment> appointments { get; set; }
    }
}
