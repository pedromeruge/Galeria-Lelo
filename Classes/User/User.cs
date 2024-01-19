using System;
using System.Text.Json.Serialization;

namespace Classes.User;
public class User
{
	public string email { get; set; } = "";
	public string username { get; set; } = "";
	public string password { get; set; } = "";

	public string rua_entrega { get; set; } = "";
	public string cod_entrega { get; set; } = "";
	public string cidade_entrega { get; set; } = "";
	public string rua_fiscal { get; set; } = "";
	public string cod_fiscal { get; set; } = "";
	public string cidade_fiscal { get; set; } = "";
}