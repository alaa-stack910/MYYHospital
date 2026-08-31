using Microsoft.AspNetCore.Mvc;
using MYYHospital.Db;
using MYYHospital.Models;
using MYYHospital.Repo.Interface;

namespace MYYHospital.Controllers
{
    public class PatientController:Controller
    {

        private readonly IPatient patient;
        private readonly AppContexts appContexts;
        public PatientController(IPatient patient, AppContexts appContexts)
        {
            this.patient = patient;
            this.appContexts = appContexts;
        }
        public IActionResult Index()
        {
            var d = patient.GetAll();
            return View(d);
        }


        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(Patient dc)
        {
            patient.Add(dc);
            return RedirectToAction(nameof(Index));
        }



        [HttpGet]

        public IActionResult Edit(int id)
        {
            var s = patient.GetId(id);
            if (s == null)
            {
                return NotFound();
            }
            return View(s);
        }

        [HttpPost]

        public IActionResult Edit(Patient dc)
        {
            patient.Update(dc);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int id)
        {
            var s = patient.GetId(id);
            if (s == null)
            {
                return NotFound();
            }
            patient.Delete(s);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int id)
        {
            var s = patient.GetId(id);
            if (s == null)
            {
                return NotFound();
            }
            return View(s);
        }

        public IActionResult Search(string name)
        {
            var s=appContexts.patients.Where(x=>x.Name.Contains(name)).ToList();
            return View(s);
        }

    }
}
