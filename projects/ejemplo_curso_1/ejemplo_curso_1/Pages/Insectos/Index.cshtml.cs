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
    public class IndexModel : PageModel
    {
        private readonly ejemplo_curso_1.Data.ejemplo_curso_1Context _context;

        public IndexModel(ejemplo_curso_1.Data.ejemplo_curso_1Context context)
        {
            _context = context;
        }

        public IList<Insecto> Insecto { get;set; }

        public async Task OnGetAsync()
        {
            Insecto = await _context.Insecto.ToListAsync();
        }
    }
}
