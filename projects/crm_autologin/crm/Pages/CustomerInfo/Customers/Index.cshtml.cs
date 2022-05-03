#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using crm.Data;
using crm.Models;

namespace crm.Pages.CustomerInfo.Customers
{
    public class IndexModel : PageModel
    {
        private readonly crm.Data.CrmContext _context;

        public IndexModel(crm.Data.CrmContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = await _context.Customer
                .Include(c => c.Address)
                .Include(c => c.Usuarios).ToListAsync();
        }
    }
}
