using MYYHospital.Db;
using MYYHospital.Models;
using MYYHospital.Repo.Interface;
using Microsoft.EntityFrameworkCore;
namespace MYYHospital.Repo.Implement
{
    public class ImAppointment:IAppointment
    {

        private readonly AppContexts context;
        public ImAppointment(AppContexts context)
        {
            this.context = context;
        }
        public List<Appointment> GetAll()
        {
            return context.appointments.Include(o=>o.patient).Include(o => o.doctor).ToList();
        }
        public Appointment GetId(int id)
        {
            return context.appointments.Include(o => o.patient).Include(o => o.doctor).FirstOrDefault(o=>o.AppointmentId==id);
        }
        public void Add(Appointment a)
        {
            context.appointments.Add(a);
            context.SaveChanges();
        }
        public void Delete(Appointment a)
        {
            context.appointments.Remove(a);
            context.SaveChanges();

        }
        public void Update(Appointment a)
        {
            context.appointments.Update(a);
            context.SaveChanges();

        }
    }
}
