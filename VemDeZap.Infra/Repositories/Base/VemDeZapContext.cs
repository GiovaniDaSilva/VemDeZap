using Microsoft.EntityFrameworkCore;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;
using VemDeZap.Domain.Entities;
using VemDeZap.Infra.Repositories.Map;

namespace VemDeZap.Infra.Repositories.Base
{
    public partial class VemDeZapContext : DbContext
    {
        //Criar as tabelas 
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Campanha> Campanha { get; set; }
        public DbSet<Envio> Envio { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Contato> Contato { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Database=VemDeZap;Uid=admin;Pwd=admin;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            base.OnModelCreating(modelBuilder);

            //ignorar classes
            modelBuilder.Ignore<Notification>();
            //modelBuilder.Ignore<Nome>();
            //modelBuilder.Ignore<Email>();

            
            //aplicar configurações
            modelBuilder.ApplyConfiguration(new MapUsuario());
            modelBuilder.ApplyConfiguration(new MapGrupo());
            modelBuilder.ApplyConfiguration(new MapContato());
            modelBuilder.ApplyConfiguration(new MapCampanha());
            modelBuilder.ApplyConfiguration(new MapEnvio());
            


            base.OnModelCreating(modelBuilder);
        }
    }
    
}
