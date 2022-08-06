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
       
    }
}
