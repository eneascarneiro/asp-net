#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ejemplo_curso_1.Data;
using ejemplo_curso_1.Models;

namespace ejemplo_curso_1.Pages.Insectos
{
    public class DeleteModel : PageModel
    {
        private readonly ejemplo_curso_1.Data.ejemplo_curso_1Context _context;

        public DeleteModel(ejemplo_curso_1.Data.ejemplo_curso_1Context context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Insecto = await _context.Insecto.FindAsync(id);

            if (Insecto != null)
            {
                _context.Insecto.Remove(Insecto);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
