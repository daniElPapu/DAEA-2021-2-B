using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lab13.Models;

namespace lab13.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        List<Persona> persons = new List<Persona>()
            {
                new Persona
                {
                    PersonID = 1,
                    FirstName = "Pedrito",
                    LastName = "Alcachofa",
                    Address = "Av. Las Zanahorias 105",
                    DateOfBirth = Convert.ToDateTime("2003-02-24"),
                    Email = "p.alcachofa@email.com"
                },
                new Persona
                {
                    PersonID = 2,
                    FirstName = "Juanito",
                    LastName = "Lechuga",
                    Address = "Urb. Los Girasoles B-3",
                    DateOfBirth = Convert.ToDateTime("2004-09-01"),
                    Email = "j.lechuga@email.com"
                },
                new Persona
                {
                    PersonID = 3,
                    FirstName = "Arnold",
                    LastName = "Swangener",
                    Address = "Av. Los Musculosos 304",
                    DateOfBirth = Convert.ToDateTime("2002-01-26"),
                    Email = "a.swangener@tecsup.edu.pe"
                },
            };
        String buscar = "";
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Listar(String buscar)
        {
            List<Persona> persons = (from p in this.persons 
                                    select p).ToList();
            if (buscar != null) { 
                persons = (from p in this.persons
                                         where p.FirstName.Contains(buscar) || p.LastName.Contains(buscar)
                                         select p).ToList();
                this.buscar = buscar;
            }
            else
            {
                if (this.buscar != "")
                {
                    persons = (from p in this.persons
                               where p.FirstName.Contains(this.buscar) || p.LastName.Contains(this.buscar)
                               select p).ToList();
                    System.Diagnostics.Debug.WriteLine("entró");

                }

            }
            System.Diagnostics.Debug.WriteLine(this.buscar);

            return View(persons);
        }
        public ActionResult Mostrar(int id)
        {
            
            Persona persona = (from p in this.persons
                               where p.PersonID == id
                               select p).FirstOrDefault();
            return View(persona);
        }
        public ActionResult Buscar(String buscar)
        {
            List<Persona> persons = (from p in this.persons
                               where p.FirstName.Contains(buscar) || p.LastName.Contains(buscar)
                               select p).ToList();

            return View(persons);
        }
    }
}