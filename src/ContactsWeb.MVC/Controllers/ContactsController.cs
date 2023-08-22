using ContactsWeb.Models;
using ContactsWeb.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        var newContact = new Contact
        {
            RegistreDate = DateTime.Today
        };
        return View("Contact", newContact);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Contact contact)
    {
        if (!ModelState.IsValid)
        {
            return View("Contact", contact);
        }

        await _contactService.InsertAsync(contact);
        TempData["NewContact"] = $"O Contato {contact.Name} foi incluído com sucesso!";

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var contact = await _contactService.FindByIdAsync(id);

        if (contact == null)
        {
            return NotFound();
        }

        return View("Contact", contact);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Contact contact)
    {
        if (!ModelState.IsValid)
        {
            return View("Contact", contact);
        }

        await _contactService.UpdateAsync(contact);
        TempData["UpdateContact"] = $"O Contato {contact.Name} foi atualizado com sucesso!";

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int id)
    {
        var contact = await _contactService.FindByIdAsync(id);

        if (contact == null)
        {
            return NotFound();
        }

        return View(contact);
    }

    [HttpPost]
    public async Task<JsonResult> Delete(int id)
    {
        var contact = await _contactService.FindByIdAsync(id);

        try
        {
            await _contactService.RemoveAsync(contact);
        }
        catch
        {
            return Json(false);
        }

        TempData["NewContact"] = $"O Contato {contact.Name} foi excluído com sucesso!";

        return Json(true);
    }
}
