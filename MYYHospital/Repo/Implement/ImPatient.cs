using MYYHospital.Db;
using MYYHospital.Models;
using MYYHospital.Repo.Interface;

namespace MYYHospital.Repo.Implement
{
    public class ImPatient:IPatient
    {
        
        private readonly AppContexts context;
        public ImPatient(AppContexts context)
        {
            this.context = context;
        }
        public List<Patient> GetAll()
        {
            return context.patients.ToList();
        }
        public Patient GetId(int id)
        {
            return context.patients.Find(id);
        }
        public void Add(Patient p)
        {
            context.patients.Add(p);
            context.SaveChanges();
        }
        public void Delete(Patient p)
        {
            context.patients.Remove(p);
            context.SaveChanges();

        }
        public void Update(Patient p)
        {
            context.patients.Update(p);
            context.SaveChanges();

        }
    }
}
