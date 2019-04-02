using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ContactController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(string option = null, string search = null)
        {
            var contacts = _db.Contacts.ToList();
            if (option == "name" && search != null)
            {
                contacts = _db.Contacts.Where(u => u.Name.ToLower().Contains(search.ToLower())).ToList();
            }

            else if (option == "phone" && search != null)
            {
                contacts = _db.Contacts.Where(u => u.Phone.ToLower().Contains(search.ToLower())).ToList();
            }

            else if (option == "address" && search != null)
            {
                contacts = _db.Contacts.Where(u => u.Address.ToLower().Contains(search.ToLower())).ToList();
            }

            return View(contacts);
        }

        public IActionResult Create()
        {
            return View();
        }
        //POST: Contact/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _db.Add(contact);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        //GET: Contact/Detail
        public async Task<IActionResult> Detail(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Contact contact = await _db.Contacts.SingleOrDefaultAsync(c => c.Id == id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        //GET: Contact/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Contact contact = await _db.Contacts.SingleOrDefaultAsync(c => c.Id == id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }
        
        //POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Edit(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", contact);
            }
            else
            {
                var contactInDB = await _db.Contacts.SingleOrDefaultAsync(c => c.Id == contact.Id);
                if(contactInDB == null)
                {
                    return NotFound();
                }
                else
                {
                    contactInDB.Name = contact.Name;
                    contactInDB.Phone = contact.Phone;
                    contactInDB.Address = contact.Address;

                    await _db.SaveChangesAsync();
                    return RedirectToAction("Index","contact");
                }
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Contact contact = await _db.Contacts.SingleOrDefaultAsync(c=>c.Id == id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        //POST:Contact/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Deleting(int id)
        {
            var contact = await _db.Contacts.SingleOrDefaultAsync(c => c.Id == id);
            _db.Remove(contact);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                _db.Dispose();
            }
        }

    }
}