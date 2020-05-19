using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CowSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<TipoGanado> TipoGanado { get; set; }
        public DbSet<TipoBalance> TipoBalance { get; set; }
        public DbSet<EstadoGanado> EstadoGanado { get; set; }
        public DbSet<Bitacora> Bitacora { get; set; }
        public DbSet<Gasto> Gasto { get; set; }
    }
}
