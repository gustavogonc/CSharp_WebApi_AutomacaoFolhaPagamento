﻿using ApiPIM.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPIM.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Funcionarios> Funcionarios { get; set; }
    }
}
