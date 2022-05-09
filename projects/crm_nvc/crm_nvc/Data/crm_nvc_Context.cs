#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using crm_nvc.Models;

namespace crm_nvc.Data
{
    public class crm_nvc_Context : DbContext
    {
        public crm_nvc_Context (DbContextOptions<crm_nvc_Context> options)
            : base(options)
        {
        }

        public DbSet<crm_nvc.Models.Usuarios> Usuarios { get; set; }

        public DbSet<crm_nvc.Models.Productos> Productos { get; set; }
    }
}
