using System.ComponentModel.DataAnnotations;

namespace olympo_webapi.Models
{
	public class Exercise
	{
		[Key]
		public int Id { get; private set; }
		public string Name { get; private set; }
		public string Description { get; private set; }
		public enum Day
		{
			Domingo,
			Segunda,
			Terça,
			Quarta,
			Quinta,
			Sexta,
			Sábado
		}
		public List<Session> sessions { get; private set; } = new List<Session>();

		public Exercise(int id, string name, string description)
		{
			Id = id;
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
