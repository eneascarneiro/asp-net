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

        public DbSet<ejemplo_curso_1.Models.Actor> Actor { get; set; }

        public DbSet<ejemplo_curso_1.Models.Director> Director { get; set; }

        public DbSet<ejemplo_curso_1.Models.Animal> Animal { get; set; }

        public DbSet<ejemplo_curso_1.Models.Insecto> Insecto { get; set; }
    }
}
