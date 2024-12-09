using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings
{
    //Fluent Map (Fluent API)
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Tabela
            builder.ToTable("Category");

            //Primary Key
            builder.HasKey(x => x.Id);

            //identity
            builder.Property(x => x.Id)
                    .ValueGeneratedOnAdd()
                    .UseIdentityColumn(); // Primary Key Identity (1,1)

            //properties
            builder.Property(x => x.Name)
                    .IsRequired() // NOT NULL
                    .HasColumnName("Name") // ATRIBUINDO UM NOME PARA COLUNA
                    .HasColumnType("NVARCHAR") //TIPO DA COLUNA
                    .HasMaxLength(80); //QUANTIDADE MAX DE CARACTERES

            builder.Property(x => x.Slug)
                    .IsRequired()
                    .HasColumnName("Slug")
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(80);

            //Indices
            builder.HasIndex(x => x.Slug, "IX_Category_Slug")
                    .IsUnique();



        }
    }
}