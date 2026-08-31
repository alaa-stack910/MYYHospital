using MYYHospital.Models;
using MYYHospital.Repo.Interface;
using MYYHospital.Db;
using Microsoft.AspNetCore.Mvc;

namespace MYYHospital.Controllers
{
    public class DoctorController:Controller
    {
        private readonly IDoctor doctor;
        public readonly AppContexts contexts;
        public DoctorController(IDoctor doctor, AppContexts contexts)
        {
            this.doctor = doctor;
            this.contexts = contexts;
        }
        public IActionResult Index()
        {
            var d = doctor.GetAll();
            return View(d);
        }


        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Doctor dc)
        {
           doctor.Add(dc);
            return RedirectToAction(nameof(Index));
        }



        [HttpGet]

        public IActionResult Edit(int id)
        {
            var s=doctor.GetId(id);
            if (s == null)
            {
                return NotFound();
            }
            return View(s);
        }

        [HttpPost]

        public IActionResult Edit(Doctor dc)
        {
            doctor.Update(dc);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int id)
        {
            var s = doctor.GetId(id);
            if (s == null)
            {
                return NotFound();
            }
            doctor.Delete(s);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int id)
        {
            var s = doctor.GetId(id);
            if (s == null)
            {
                return NotFound();
            }
            return View(s);
        }

        public IActionResult Search(string name)
        {

            var s=contexts.doctors.Where(x=>x.Name.Contains(name)).ToList();
            return View(s);
        }

    }
}
