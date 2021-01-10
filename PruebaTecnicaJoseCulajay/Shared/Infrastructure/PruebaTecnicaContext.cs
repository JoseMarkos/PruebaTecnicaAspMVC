using Microsoft.EntityFrameworkCore;
using PruebaTecnicaJoseCulajay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaJoseCulajay.Shared.Infrastructure
{
    public class PruebaTecnicaContext: DbContext
    {
            public DbSet<Plaza> Plazas { get; set; }
            public DbSet<Escolaridad> NivelEscolaridad { get; set; }
            public DbSet<Candidato> Candidatos { get; set; }

        public PruebaTecnicaContext(DbContextOptions<PruebaTecnicaContext> options) : base(options)
        {

        }
    }
}
