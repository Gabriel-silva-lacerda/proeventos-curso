﻿using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;


namespace ProEventos.Data
{
    public class ProEventosContext : DbContext
    {
        public ProEventosContext(DbContextOptions<ProEventosContext> options): base(options)
        {
        }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }
        public DbSet<RedeSocial> RedeSociais { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(PE => new { PE.EventoId, PE.PalestranteId});

            modelBuilder.Entity<Evento>().HasMany(e => e.RedeSociais).WithOne(rs => rs.Evento).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Palestrante>().HasMany(e => e.RedeSociais).WithOne(rs => rs.Palestrante).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
