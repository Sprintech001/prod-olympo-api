﻿using Microsoft.EntityFrameworkCore;
using olympo_webapi.Infrastructure;
using olympo_webapi.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using olympo_webapi.Services;

namespace olympo_webapi.Infrastructure
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Gym> Gyms { get; set; }
        public DbSet<GymUser> GymUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserExercise> UserExercises { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Session> Sessions { get; set; }

        public ConnectionContext(DbContextOptions<ConnectionContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Gym>(entity =>
            {
                entity.Property(g => g.Id).ValueGeneratedOnAdd();
                entity.HasKey(g => g.Id);
                entity.Property(g => g.Name).IsRequired().HasMaxLength(100);
                entity.Property(g => g.Address).IsRequired().HasMaxLength(200);
                entity.Property(g => g.PhoneNumber).IsRequired().HasMaxLength(15);
                entity.Property(g => g.Email).IsRequired().HasMaxLength(100);
                entity.Property(g => g.Website).IsRequired(false).HasMaxLength(100);
                entity.Property(g => g.Description).IsRequired(false).HasMaxLength(500);
                entity.Property(g => g.ImageUrl).IsRequired(false).HasMaxLength(200);
            });

            modelBuilder.Entity<GymUser>(entity =>
            {
                entity.HasKey(gu => new { gu.UserId, gu.GymId });

                entity.HasOne(gu => gu.User)
                    .WithMany(u => u.Gyms)
                    .HasForeignKey(gu => gu.UserId)
                    .OnDelete(DeleteBehavior.Cascade); 

                entity.HasOne(gu => gu.Gym)
                    .WithMany(g => g.Users)
                    .HasForeignKey(gu => gu.GymId)
                    .OnDelete(DeleteBehavior.Cascade); 
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(u => u.Id).ValueGeneratedOnAdd();
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Name).IsRequired().HasMaxLength(100);
                entity.Property(u => u.Email).IsRequired().HasMaxLength(100);
                entity.Property(u => u.Password).IsRequired();
                entity.Property(u => u.Type).HasConversion<string>();
            });

            modelBuilder.Entity<UserExercise>(entity =>
            {
                entity.HasKey(ue => new { ue.UserId, ue.ExerciseId });

                entity.HasOne(ue => ue.User)
                    .WithMany(u => u.Exercises)
                    .HasForeignKey(ue => ue.UserId)
                    .OnDelete(DeleteBehavior.Cascade); 

                entity.HasOne(ue => ue.Exercise)
                    .WithMany(e => e.Users)
                    .HasForeignKey(ue => ue.ExerciseId)
                    .OnDelete(DeleteBehavior.Cascade); 
            });

            modelBuilder.Entity<Exercise>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(500);
                entity.Property(e => e.ImagePath).IsRequired(false);
                entity.Property(e => e.VideoPath).IsRequired(false);
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.Property(s => s.Id).ValueGeneratedOnAdd();
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Repetitions).IsRequired();
                entity.Property(s => s.Series).IsRequired();
                entity.Property(s => s.Time).IsRequired();

                entity.HasOne(s => s.Exercise)
                    .WithMany(e => e.Sessions)
                    .HasForeignKey(s => s.ExerciseId)
                    .OnDelete(DeleteBehavior.Cascade); 

                entity.HasOne(s => s.User)
                    .WithMany() 
                    .HasForeignKey(s => s.UserId)
                    .OnDelete(DeleteBehavior.SetNull); 
            });

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, CPF = "123.456.789-01", Name = "Admin", Type = UserType.Administrador, Email = "adm@gmail.com", ImagePath = "defaultphoto.jpg", Password = HashService.HashPassword("password") },
                new User { Id = 2, CPF = "987.654.321-09", Name = "José", Type = UserType.Professor, Email = "jose@gmail.com", ImagePath = "defaultphoto.jpg", Password = HashService.HashPassword("password") },
                new User { Id = 3, CPF = "111.222.333-44", Name = "Maria", Type = UserType.Aluno, Email = "maria@gmail.com", ImagePath = "defaultphoto.jpg", Password = HashService.HashPassword("password") },
                new User { Id = 4, CPF = "555.666.777-88", Name = "João", Type = UserType.Aluno, Email = "joao@gmail.com", ImagePath = "defaultphoto.jpg", Password = HashService.HashPassword("password") }
            );

            modelBuilder.Entity<Exercise>().HasData(
                new Exercise { Id = 1, Name = "Agachamento Terra", Description = "Descrição do exercício", ImagePath = "images/exe2.png", VideoPath = "videos/execucao.mp4" },
                new Exercise { Id = 2, Name = "Rosca Concentrada", Description = "Descrição do exercício", ImagePath = "images/exe.png", VideoPath = "videos/execucao.mp4" },
                new Exercise { Id = 3, Name = "Supino Reto", Description = "Descrição do exercício", ImagePath = "images/exe3.png", VideoPath = "videos/execucao.mp4" },
                new Exercise { Id = 4, Name = "Puxada Aberta", Description = "Descrição do exercício", ImagePath = "images/exe4.png", VideoPath = "videos/execucao.mp4" },
                new Exercise { Id = 5, Name = "Levantamento Terra", Description = "Descrição do exercício", ImagePath = "images/exe5.png", VideoPath = "videos/execucao.mp4" }
            );
        }

    }
}
