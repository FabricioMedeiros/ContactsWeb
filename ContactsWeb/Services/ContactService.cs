using ContactsWeb.Data;
using ContactsWeb.Models;
using ContactsWeb.Services.Exceptions;
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

        public async Task<Contact> FindByIdAsync(int id)
        {
            return await _context.Contacts.Include(a => a.Address).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Contact contact)
        {
            bool hasAny = await _context.Contacts.AnyAsync(c => c.Id == contact.Id);

            if (!hasAny)
            {
                throw new NotFoundException("Id não encontado.");
            }

            try
            {
                contact.Phone = StringExtensions.RemoveMask(contact.Phone);
                contact.Address.ZipCode = StringExtensions.RemoveMask(contact.Address.ZipCode);

                _context.Contacts.Update(contact);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

    }

}

