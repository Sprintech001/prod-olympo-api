using Microsoft.EntityFrameworkCore;
using olympo_webapi.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using olympo_webapi.Services;

namespace olympo_webapi.Infrastructure
{
    public class ConnectionContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<ExerciseDay> ExerciseDays { get; set; }

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

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(u => u.Id).ValueGeneratedOnAdd();
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Name).IsRequired().HasMaxLength(100);
                entity.Property(u => u.Email).IsRequired().HasMaxLength(100);
                entity.Property(u => u.Password).IsRequired();
                entity.Property(u => u.Type).HasConversion<string>();
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
            });

            modelBuilder.Entity<ExerciseDay>(entity =>
            {
                entity.Property(ed => ed.Id).ValueGeneratedOnAdd();
                entity.HasKey(ed => ed.Id);
                
                entity.Property(ed => ed.UserId).IsRequired(false);
                entity.Property(ed => ed.ExerciseId).IsRequired(false);
                entity.Property(ed => ed.SessionId).IsRequired(false);
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

            modelBuilder.Entity<Session>().HasData(
                new Session { Id = 1, Repetitions = 10, Series = 3, Breaks = 60.0, Time = 5.0, ExerciseId = 1 },
                new Session { Id = 2, Repetitions = 12, Series = 4, Breaks = 45.0, Time = 6.0, ExerciseId = 2 },
                new Session { Id = 3, Repetitions = 8, Series = 5, Breaks = 90.0, Time = 7.5, ExerciseId = 3 },
                new Session { Id = 4, Repetitions = 15, Series = 3, Breaks = 30.0, Time = 4.5, ExerciseId = 4 },
                new Session { Id = 5, Repetitions = 6, Series = 6, Breaks = 120.0, Time = 10.0, ExerciseId = 5 }
            );

            modelBuilder.Entity<ExerciseDay>().HasData(
                new ExerciseDay { Id = 1, ExerciseId = 1, DayOfWeek = "Segunda", SessionId = 1, UserId = 3 },
                new ExerciseDay { Id = 2, ExerciseId = 2, DayOfWeek = "Terça", SessionId = 2, UserId = 4 },
                new ExerciseDay { Id = 3, ExerciseId = 3, DayOfWeek = "Quarta", SessionId = 3, UserId = 3 },
                new ExerciseDay { Id = 4, ExerciseId = 4, DayOfWeek = "Domingo", SessionId = 4, UserId = 3 },
                new ExerciseDay { Id = 5, ExerciseId = 5, DayOfWeek = "Segunda", SessionId = 5, UserId = 4 }
            );
        }
    }
}