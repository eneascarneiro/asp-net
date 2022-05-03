#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using crm.Models;

namespace crm.Data
{
    public class CrmContext : DbContext
    {
        public CrmContext(DbContextOptions<CrmContext> options)
            : base(options)
        {
        }

        public DbSet<crm.Models.Address> Address { get; set; }

        public DbSet<crm.Models.Company> Company { get; set; }

        public DbSet<crm.Models.Customer> Customer { get; set; }

        public DbSet<crm.Models.Invoice> Invoice { get; set; }

        public DbSet<crm.Models.Pedidos> Pedidos { get; set; }

        public DbSet<crm.Models.Productos> Productos { get; set; }

        public DbSet<crm.Models.Usuarios> Usuarios { get; set; }
    }
}
