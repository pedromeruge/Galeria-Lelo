using System;
using System.Text.Json.Serialization;

namespace Classes.Admin {
    public class Admin
    {
		public int admin_id { get; set; } = -1;
		public string email { get; set; } = "";
		public string pass_hash { get; set; } = "";
    }
}
