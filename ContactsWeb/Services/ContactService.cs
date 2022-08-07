using ContactsWeb.Data;
using ContactsWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsWeb.Services
{
    public class ContactService
    {
        private readonly ContactsWebDbContext _context;

        public ContactService(ContactsWebDbContext context)
        {
            _context = context;
        }
        public async Task<List<Contact>> FindAllAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task InsertAsync(Contact contact)
        {
            contact.Phone = StringExtensions.RemoveMask(contact.Phone);
            contact.Address.ZipCode = StringExtensions.RemoveMask(contact.Address.ZipCode);

            _context.Add(contact);
            await _context.SaveChangesAsync();
        }
    }
}
