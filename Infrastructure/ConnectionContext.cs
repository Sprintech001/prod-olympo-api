using Microsoft.EntityFrameworkCore;
using olympo_webapi.Models;

namespace olympo_webapi.Infrastructure
{
	public class ConnectionContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Exercise> Exercises { get; set; }
		public DbSet<Session> Sessions { get; set; }

		public ConnectionContext(DbContextOptions<ConnectionContext> options)
		: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<User>(entity =>
			{
				entity.HasKey(u => u.Id);
				entity.Property(u => u.Name).IsRequired().HasMaxLength(100);
				entity.Property(u => u.Email).IsRequired().HasMaxLength(100);
				entity.Property(u => u.Password).IsRequired();
			});

			modelBuilder.Entity<Exercise>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
			});

			modelBuilder.Entity<Session>(entity =>
			{
				entity.HasKey(s => s.Id);
				entity.Property(s => s.Repetitions).IsRequired();
				entity.Property(s => s.Series).IsRequired();
				entity.Property(s => s.Time).IsRequired();
			});

			modelBuilder.Entity<User>().HasData(
				new User
				{
					Id = 1,
					CPF = "123.456.789-01",
					Name = "Admin",
					Email = "adm@gmail.com",
					ImagePath = "defaultphoto.jpg",
					Password = "password"
				}
			);

			modelBuilder.Entity<Exercise>().HasData(
			new Exercise
			{
				Id = 1,
				Name = "Agachamento Terra",
				Description = "Use uma pegada pronada, com as palmas das mãos voltadas para o corpo, para segurar a barra. Mantenha os joelhos flexionados na posição de agachamento, a coluna ereta e alinhada, e as pernas abertas com os pés apontados para fora.",
				Day = (int?)Day.Sexta,
				ImagePath = "images/exe2.png",
				VideoPath = "videos/execucao.mp4"
			},
			new Exercise
			{
				Id = 2,
				Name = "Rosca Concentrada",
				Description = "Sente-se em um banco e incline-se levemente, mantendo o peito erguido. Flexione o braço para levantar o halter até o ombro, pause por um segundo no topo e estenda lentamente o braço para retornar à posição inicial.",
				Day = (int?)Day.Sexta,
				ImagePath = "images/exe.png",
				VideoPath = "videos/execucao.mp4"
			}
		);
			base.OnModelCreating(modelBuilder);
		}
	}
}