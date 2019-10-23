using LojaVirtual.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Data
{
    public class ApplicationDbContext : DbContext
    {
        DbSet<Cliente> Clientes { get; set; }
        DbSet<NewsLetterEmail> NewsLetterEmails { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

    }
}
