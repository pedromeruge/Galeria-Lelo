using System;
using System.Text.Json.Serialization;

namespace Classes.User {
    public class User
    {
		public int user_id { get; set; } = -1;
        public string rua_fiscal { get; set; } = "";
        public string cidade_fiscal { get; set; } = "";
        public string codpostal_fiscal { get; set; } = "";
        public string rua_entrega { get; set; } = "";
        public string cidade_entrega { get; set; } = "";
        public string codpostal_entrega { get; set; } = "";
		public string foto { get; set; } = "";
        public string email { get; set; } = "";
        public string username { get; set; } = "";
        public string pass_hash { get; set; } = "";
		public DateTime data_registo { get; set; }

    }
}
