#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using crm.Data;
using crm.Models;

namespace crm.Pages.CustomerInfo.Customers
{
    public class CreateModel : PageModel
    {
        private readonly crm.Data.CrmContext _context;

        public CreateModel(crm.Data.CrmContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Address_Id"] = new SelectList(_context.Address, "ID", "ID");
        ViewData["User_Id"] = new SelectList(_context.Usuarios, "ID", "USUARIO");
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Customer.Add(Customer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
