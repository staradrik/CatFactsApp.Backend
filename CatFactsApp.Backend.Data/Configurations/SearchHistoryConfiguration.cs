using CatFactsApp.Backend.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatFactsApp.Backend.Data.Configurations
{
    public class SearchHistoryConfiguration : IEntityTypeConfiguration<SearchHistory>
    {
        public void Configure(EntityTypeBuilder<SearchHistory> builder)
        {
            builder.ToTable("SearchHistory");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.SearchDate)
                .IsRequired();

            builder.Property(e => e.CatFact)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(e => e.Query)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.GifUrl)
                .IsRequired()
                .HasMaxLength(500);
        }
    }
}
