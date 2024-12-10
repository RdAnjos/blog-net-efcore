using System;
using System.Collections.Generic;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Blog.Data.Mappings
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            //table
            builder.ToTable("Post");

            //PK
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                    .ValueGeneratedOnAdd()
                    .UseIdentityColumn();

            //properties
            builder.Property(x => x.LastUpdateDate)
                    .IsRequired()
                    .HasColumnName("LastUpdateDate")
                    .HasColumnType("SMALLDATETIME")
                    .HasDefaultValueSql("GETDATE()");
            //.HasDefaultValue(DateTime.Now.ToUniversalTime());

            //INDEX
            builder.HasIndex(x => x.Slug, "IX_Post_Slug")
                    .IsUnique();

            //relacionamentos 1 > Muitos
            builder.HasOne(x => x.Author)
                    .WithMany(x => x.Posts)
                    .HasConstraintName("FK_Post_Author")
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Category)
                    .WithMany(x => x.Posts)
                    .HasConstraintName("FK_Post_Category")
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Tags)
                    .WithMany(x => x.Posts)
                    .UsingEntity<Dictionary<string, object>>(
                        "PostTag",
                        post => post.HasOne<Tag>()
                                .WithMany()
                                .HasForeignKey("PostId")
                                .HasConstraintName("FK_PostTag_PostId")
                                .OnDelete(DeleteBehavior.Cascade),
                        tag => tag.HasOne<Post>()
                                .WithMany()
                                .HasForeignKey("TagId")
                                .HasConstraintName("FK_PostTag_TagId")
                                .OnDelete(DeleteBehavior.Cascade)
                    );

        }
    }
}