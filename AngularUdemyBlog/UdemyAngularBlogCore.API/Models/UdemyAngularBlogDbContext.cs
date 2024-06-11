﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UdemyAngularBlogCore.API.Models;

public partial class UdemyAngularBlogDbContext : DbContext
{
    public UdemyAngularBlogDbContext()
    {
    }

    public UdemyAngularBlogDbContext(DbContextOptions<UdemyAngularBlogDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SCARYEMRE\\SQLEXPRESS;Database=UdemyAngularBlogDB;Integrated Security=True;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.ToTable("Article");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.ContentMain).HasColumnName("content_main");
            entity.Property(e => e.ContentSummary)
                .HasMaxLength(500)
                .HasColumnName("content_summary");
            entity.Property(e => e.Picture)
                .HasMaxLength(300)
                .HasColumnName("picture");
            entity.Property(e => e.PublishDate)
                .HasColumnType("datetime")
                .HasColumnName("publish_date");
            entity.Property(e => e.Title)
                .HasMaxLength(500)
                .HasColumnName("title");
            entity.Property(e => e.ViewCount).HasColumnName("viewCount");

            entity.HasOne(d => d.Category).WithMany(p => p.Articles)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Article_Category");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.ToTable("Comment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ArticleId).HasColumnName("article_id");
            entity.Property(e => e.ContentMain).HasColumnName("content_main");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.PublishDate)
                .HasColumnType("datetime")
                .HasColumnName("publish_date");

            entity.HasOne(d => d.Article).WithMany(p => p.Comments)
                .HasForeignKey(d => d.ArticleId)
                .HasConstraintName("FK_Comment_Article");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
