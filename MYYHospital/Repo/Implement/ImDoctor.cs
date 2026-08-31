using MYYHospital.Db;
using MYYHospital.Models;
using MYYHospital.Repo.Interface;

namespace MYYHospital.Repo
{
    public class ImDoctor:IDoctor
    {

        private readonly AppContexts context;
        public ImDoctor(AppContexts context)
        {
            this.context = context;
        }
        public List<Doctor> GetAll()
        {
            return context.doctors.ToList();
        }
        public Doctor GetId(int id)
        {
            return context.doctors.Find(id);
        }
        public void Add(Doctor doctor)
        {
            context.doctors.Add(doctor);
            context.SaveChanges();
        }
        public void Delete(Doctor doctor)
        {
            context.doctors.Remove(doctor);
            context.SaveChanges();

        }
        public void Update(Doctor doctor)
        {
            context.doctors.Update(doctor);
            context.SaveChanges();

        }
    }
}
