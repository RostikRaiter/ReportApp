using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniversityReportApp.Domain.Entities;

namespace UniversityReportApp.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<Professor, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Professor> Professors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Report> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Professor>(p =>
            {
                p.HasKey(p => p.Id);
                p.Property(p => p.FirstName).HasMaxLength(100).IsRequired();
                p.Property(p => p.LastName).HasMaxLength(100).IsRequired();
                p.Property(p => p.MiddleName).HasMaxLength(100);
                p.Property(p => p.Email).HasMaxLength(200);
                p.HasOne(p => p.Department)
                    .WithMany(d => d.Professors)
                    .HasForeignKey(p => p.DepartmentId);
            });

            modelBuilder.Entity<Department>(d =>
            {
                d.HasKey(d => d.Id);
                d.Property(d => d.Name).HasMaxLength(200).IsRequired();
                d.HasOne(d => d.Faculty)
                    .WithMany(f => f.Departments)
                    .HasForeignKey(d => d.FacultyId);
            });

            modelBuilder.Entity<Faculty>(f =>
            {
                f.HasKey(f => f.Id);
                f.Property(f => f.Name).HasMaxLength(200).IsRequired();
            });

            modelBuilder.Entity<Report>(r =>
            {
                r.HasKey(r => r.Id);
                r.Property(r => r.Title).HasMaxLength(200).IsRequired();
                r.Property(r => r.Content).IsRequired();
                r.Property(r => r.Date).IsRequired();
                r.HasOne(r => r.Professor)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(r => r.ProfessorId);
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}








