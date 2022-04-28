#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ejemplo_curso_1.Data;
using ejemplo_curso_1.Models;

namespace ejemplo_curso_1.Pages.Insectos
{
    public class EditModel : PageModel
    {
        private readonly ejemplo_curso_1.Data.ejemplo_curso_1Context _context;

        public EditModel(ejemplo_curso_1.Data.ejemplo_curso_1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Insecto Insecto { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Insecto = await _context.Insecto.FirstOrDefaultAsync(m => m.ID == id);

            if (Insecto == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Insecto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsectoExists(Insecto.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool InsectoExists(int id)
        {
            return _context.Insecto.Any(e => e.ID == id);
        }
    }
}
