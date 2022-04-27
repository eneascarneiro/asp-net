#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ejemplo_curso_1.Models;

namespace ejemplo_curso_1.Data
{
    public class ejemplo_curso_1Context : DbContext
    {
        public ejemplo_curso_1Context (DbContextOptions<ejemplo_curso_1Context> options)
            : base(options)
        {
        }

        public DbSet<ejemplo_curso_1.Models.Pelicula> Pelicula { get; set; }
    }
}
