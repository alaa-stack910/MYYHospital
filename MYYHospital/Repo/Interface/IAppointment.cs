using MYYHospital.Models;

namespace MYYHospital.Repo.Interface
{
    public interface IAppointment
    {

        public List<Appointment> GetAll();
        public Appointment GetId(int id);
        public void Add(Appointment a);
        public void Delete(Appointment a);
        public void Update(Appointment a);
    }
}
