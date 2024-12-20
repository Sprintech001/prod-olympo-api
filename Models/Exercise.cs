using System.ComponentModel.DataAnnotations;

namespace olympo_webapi.Models
{
	public class Exercise
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public enum Day
		{
			Domingo = 0,
			Segunda = 1,
			Terca = 2,
			Quarta = 3,
			Quinta = 4,
			Sexta = 5,
			Sabado = 6
		}
		public List<Session> sessions { get; set; } = new List<Session>();

		public Exercise(int id, string name, string description)
		{
			Id = id;
			Name = name;
			Description = description;
		}

		public void UpdateDetails(string name, string description)
		{
			Name = name;
			Description = description;
		}

		public void AddSession(Session session)
		{
			if (session != null)
			{
				sessions.Add(session);
			}
		}
	}
}
