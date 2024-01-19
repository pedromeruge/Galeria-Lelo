using System;
using System.Text.Json.Serialization;

namespace Classes.Session {
    public class Session
    {
		public int sessao_id { get; set; } = -1;

		public DateTime data_hora_inicio { get; set; }

		public DateTime data_hora_fim { get; set; }

		public int user_id { get; set; } = -1;
    }
}