using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Asp.net_core_CRUD.Models;

namespace Asp.net_core_CRUD.Data
{
    public class Aspnet_core_CRUDContext : DbContext
    {
        public Aspnet_core_CRUDContext (DbContextOptions<Aspnet_core_CRUDContext> options)
            : base(options)
        {
        }

        public DbSet<Asp.net_core_CRUD.Models.books> books { get; set; } = default!;
    }
}
