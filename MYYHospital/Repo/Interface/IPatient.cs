using MYYHospital.Models;

namespace MYYHospital.Repo.Interface
{
    public interface IPatient
    {
        public List<Patient> GetAll();
        public Patient GetId(int id);
        public void Add(Patient p);
        public void Delete(Patient p);
        public void Update(Patient p);
    }
}
