﻿using AppConcursos.Models;
using Microsoft.EntityFrameworkCore;

namespace AppConcursos.Contexto
{
    public class ContextoBD : DbContext
    {
        public ContextoBD(DbContextOptions<ContextoBD> options) : base(options) { }

        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Inscricao> Inscricoes { get; set; }
    }
}
