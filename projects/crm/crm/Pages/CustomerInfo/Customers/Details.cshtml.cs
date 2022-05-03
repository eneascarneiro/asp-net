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
    public class DetailsModel : PageModel
    {
        private readonly crm.Data.CrmContext _context;

        public DetailsModel(crm.Data.CrmContext context)
        {
            _context = context;
        }

        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customer
                .Include(c => c.Address)
                .Include(c => c.Usuarios).FirstOrDefaultAsync(m => m.ID == id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
