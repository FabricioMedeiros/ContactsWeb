using ContactsWeb.Models;
using ContactsWeb.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsWeb.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactService _contactService;

        public ContactsController(ContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _contactService.FindAllAsync();

            list = list.OrderBy(c => c.Name).ToList();

            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var contact = new Contact
            {
                RegistreDate = System.DateTime.Today
            };

            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }
                        
            await _contactService.InsertAsync(contact);
                        
            return RedirectToAction(nameof(Index));
        }

    }
}
