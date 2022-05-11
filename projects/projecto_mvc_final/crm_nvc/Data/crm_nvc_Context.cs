#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using crm_mvc.Models;

namespace crm_mvc.Data
{
    public class crm_mvc_Context : DbContext
    {
        public crm_mvc_Context (DbContextOptions<crm_mvc_Context> options)
            : base(options)
        {
        }

        public DbSet<crm_mvc.Models.Usuarios> Usuarios { get; set; }

        public DbSet<crm_mvc.Models.Productos> Productos { get; set; }

        public DbSet<crm_mvc.Models.LoginUsuario> LoginUsuario { get; set; }

        public DbSet<crm_mvc.Models.Customer> Customer { get; set; }
    }
}
