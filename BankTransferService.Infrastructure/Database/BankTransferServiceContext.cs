using BankTransferService.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BankTransferService.Infrastructure.Database
{
    public class BankTransferServiceContext : DbContext
    {
        public BankTransferServiceContext(DbContextOptions<BankTransferServiceContext> options)
            : base(options)
        {
        }

        public DbSet<FlutterwaveBankList> FlutterwaveBankLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
