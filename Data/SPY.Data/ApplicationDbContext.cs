using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SPY.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPY.Data
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationIdentityUser, ApplicationIdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions option):base(option)
        {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationIdentityUser>(b =>
            {
                //b.HasKey(l => l.UserId);
                //b.Property(l => l.UserId).HasMaxLength(50);
            });
            modelBuilder.Entity<CommentReply>().HasOne(l => l.Comment).WithMany(l => l.CommentReplies).HasForeignKey(l => l.CommentId);
            modelBuilder.Entity<Student>().HasOne(l => l.Desk).WithOne(l => l.Student).HasForeignKey<Student>(l => l.DeskID);
            modelBuilder.Entity<Teacher>().HasOne(l => l.School).WithMany(l => l.Teachers).HasForeignKey(l => l.SchoolID);
            modelBuilder.Entity<RelationShip>().HasKey(l => new { l.ChildID, l.ParentID });
            modelBuilder.Entity<Comment>().HasOne(l => l.Article).WithMany(l => l.Comments).HasForeignKey(l => l.ArticleId);
            modelBuilder.Entity<RelationShip>().HasOne(l => l.Child).WithMany(l => l.RelationShips).HasForeignKey(l => l.ChildID);
            modelBuilder.Entity<RelationShip>().HasOne(l => l.Parent).WithMany(l => l.RelationShips).HasForeignKey(l => l.ParentID);
            modelBuilder.Entity<SiteInfo>().HasKey(l => l.Id);
            modelBuilder.Entity<Article>().HasOne(l => l.Author).WithMany(l => l.Articles).HasForeignKey(l => l.UserId);
            modelBuilder.Entity<Article>().HasOne(l => l.CategoryNavigation).WithMany(l => l.Articles).HasForeignKey(l => l.CategoryId);
            modelBuilder.Entity<Article>(b =>
            {
                b.HasOne(l => l.Author).WithMany(l => l.Articles).HasForeignKey(l => l.UserId);
                b.Property(l => l.UserId)/*.HasMaxLength(50)*/;
            });
        }
        public DbSet<LatestNews> LatestNews { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Desk> Desks { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Child> children { get; set; }
        public DbSet<Parent> parents { get; set; }
        public DbSet<RelationShip> relationShips { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<SiteInfo> SiteInfo { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
