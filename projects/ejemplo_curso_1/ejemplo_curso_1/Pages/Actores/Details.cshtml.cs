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

namespace ejemplo_curso_1.Pages.Actores
{
    public class DetailsModel : PageModel
    {
        private readonly ejemplo_curso_1.Data.ejemplo_curso_1Context _context;

        public DetailsModel(ejemplo_curso_1.Data.ejemplo_curso_1Context context)
        {
            _context = context;
        }

        public Actor Actor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Actor = await _context.Actor.FirstOrDefaultAsync(m => m.ID == id);

            if (Actor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
