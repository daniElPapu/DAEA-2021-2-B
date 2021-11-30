using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Practica4.Models;

namespace Practica4.Controllers
{
    public class PrestamoesController : Controller
    {
        private bibliotecaEntities db = new bibliotecaEntities();

        // GET: Prestamoes
        public async Task<ActionResult> Index()
        {
            var prestamo = db.Prestamo.Include(p => p.Libro).Include(p => p.Usuario);
            return View(await prestamo.ToListAsync());
        }

        // GET: Prestamoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamo prestamo = await db.Prestamo.FindAsync(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            return View(prestamo);
        }

        // GET: Prestamoes/Create
        public ActionResult Create()
        {
            ViewBag.IdLibro = new SelectList(db.Libro, "IdLibro", "Titulo");
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "NIF");
            return View();
        }

        // POST: Prestamoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdPrestamo,FecPrestamo,FecDevolucion,IdLibro,IdUsuario")] Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                db.Prestamo.Add(prestamo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdLibro = new SelectList(db.Libro, "IdLibro", "Titulo", prestamo.IdLibro);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "NIF", prestamo.IdUsuario);
            return View(prestamo);
        }

        // GET: Prestamoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamo prestamo = await db.Prestamo.FindAsync(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdLibro = new SelectList(db.Libro, "IdLibro", "Titulo", prestamo.IdLibro);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "NIF", prestamo.IdUsuario);
            return View(prestamo);
        }

        // POST: Prestamoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdPrestamo,FecPrestamo,FecDevolucion,IdLibro,IdUsuario")] Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prestamo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdLibro = new SelectList(db.Libro, "IdLibro", "Titulo", prestamo.IdLibro);
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "NIF", prestamo.IdUsuario);
            return View(prestamo);
        }

        // GET: Prestamoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamo prestamo = await db.Prestamo.FindAsync(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            return View(prestamo);
        }

        // POST: Prestamoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Prestamo prestamo = await db.Prestamo.FindAsync(id);
            db.Prestamo.Remove(prestamo);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
