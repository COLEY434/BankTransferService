using BankTransferService.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransferService.Infrastructure.Database.Config
{
    internal class FlutterwaveBankListConfiguration : IEntityTypeConfiguration<FlutterwaveBankList>
    {
        public void Configure(EntityTypeBuilder<FlutterwaveBankList> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(k => k.BankCode).HasMaxLength(6).IsRequired();
            builder.Property(k => k.BankName).HasMaxLength(30).IsRequired();
            builder.HasIndex(k => k.BankCode).IsUnique();
        }
    }
}
