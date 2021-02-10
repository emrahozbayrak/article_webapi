using System;
using Article.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Article.DataAccess
{
    public partial class ArticleDBContext : DbContext
    {
        public ArticleDBContext()
        {
        }

        public ArticleDBContext(DbContextOptions<ArticleDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article.Core.Entities.Article> Articles { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Article.Core.Entities.Article>(entity =>
            {
                entity.ToTable("Article");

                entity.Property(e => e.ArticleContent).HasColumnType("ntext");

                entity.Property(e => e.ArticleTitle).HasMaxLength(200);

                entity.Property(e => e.AuthorName).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.CommentContent).HasColumnType("ntext");

                entity.Property(e => e.CommentWriter).HasMaxLength(100);

                entity.Property(e => e.CreatedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("smalldatetime");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Comment_Article");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
