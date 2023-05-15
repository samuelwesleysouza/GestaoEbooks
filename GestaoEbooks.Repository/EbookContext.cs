using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using GestaoEbooks.Repository.Models.ModelsTableBancoDD;

namespace GestaoEbooks.Repository
{
    public class PessoaContext : DbContext
    {
        public PessoaContext(DbContextOptions<PessoaContext> options) : base(options) { }

        public DbSet<TabUsuario> Usuarios { get; set; }
        public DbSet<TabEbook> tabEbooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TabUsuario>().ToTable("tabUsuario");
            modelBuilder.Entity<TabEbook>().ToTable("tabEbook");
        }
    }
}
