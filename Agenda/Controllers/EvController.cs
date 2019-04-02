using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Controllers
{
    public class EvController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EvController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index(string option = null, string search = null)
        {
            var ev = _db.Events.ToList();

            //if (option == "date" && search != null)
            //{
            //   // ev = _db.Events.Where(e => e.Date == search);

            //}

            return View(ev);
        }

        public IActionResult Create()
        {
            return View();
        }
        //POST: Contact/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Event ev)
        {
            if (ModelState.IsValid)
            {
                _db.Add(ev);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ev);
        }

        //GET: Contact/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Event ev = await _db.Events.SingleOrDefaultAsync(e => e.Id == id);
            if (ev == null)
            {
                return NotFound();
            }
            return View(ev);
        }

        //POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Event ev)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", ev);
            }
            else
            {
                var EventInDB = await _db.Events.SingleOrDefaultAsync(e => e.Id == ev.Id);
                if (EventInDB == null)
                {
                    return NotFound();
                }
                else
                {
                    EventInDB.EventName = ev.EventName;
                    EventInDB.Date = ev.Date;
                    EventInDB.Location = ev.Location;

                    await _db.SaveChangesAsync();
                    return RedirectToAction("Index", "ev");
                }
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Event ev = await _db.Events.SingleOrDefaultAsync(e => e.Id == id);
            if (ev == null)
            {
                return NotFound();
            }
            return View(ev);
        }

        //POST:Contact/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deleting(int id)
        {
            var ev = await _db.Events.SingleOrDefaultAsync(e => e.Id == id);
            _db.Remove(ev);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
        }
    }
}