using Classes.User;
using Classes.Session;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;

namespace DataLayer.UserService {

    public class UserService : IUserService {
		private ISqlDataAccess db;

		public UserService(ISqlDataAccess data)
        {
            db = data;
        }

		public async Task<User> getUser(string email) {
			const string userSQL = "SELECT user_id, rua_fiscal, cidade_fiscal, codpostal_fiscal, rua_entrega, cidade_entrega, codpostal_entrega, foto, email, username, pass_hash, data_registo FROM Utilizador WHERE email = @Email";
			List<User> userList = await db.LoadData<User, dynamic>(userSQL, new { Email = email });
			if (userList.Count > 0)
			{
				User user = userList[0];
				// Console.WriteLine("Encontrado user");
				// Console.WriteLine(user.username);
				return user;
			} else {
				// throw new InvalidOperationException();
				// Console.WriteLine("User nao existe");
				return null;
			}
		}

		private async Task<Session> getSession(int session_id) {
			const string sessionSQL = "SELECT sessao_id, data_hora_inicio, data_hora_fim, user_id FROM Sessao WHERE sessao_id = @Id";
			List<Session> sessionList = await db.LoadData<Session, dynamic>(sessionSQL, new { Id = session_id });
			if (sessionList.Count > 0)
			{
				Session session = sessionList[0];

				return session;
			} else {
				// throw new InvalidOperationException();
				return null;
			}
		}

		public async Task<bool> checkUserValid(User user) {
			User dbUser = await getUser(user.email);
			if (dbUser != null && user.pass_hash != dbUser.pass_hash) {
				return false;
			}
			return true;
		}

		public async Task<bool> checkUserValidSession(User user, Session session) {
			// vai buscar session e user a BD para garantir que ta tudo atualizado
			User dbUser = await getUser(user.email);
			if (dbUser == null) return false;

			if (session.sessao_id < 0) return false;
			Session dbSession = await getSession(session.sessao_id);
			if (dbSession == null) return false;

			// 1. ver se session corresponde aquele user
			if (dbSession.user_id != dbUser.user_id) {
				return false;
			}
			// TODO
			// 2. ver se session ja acabou
			// if (dbSession.data_hora_fim) {

			// }
			return true;
		}
		public async Task<Session> createSessionFor(User user) {
			User dbUser = await getUser(user.email);

			const string sessionSQL = "INSERT INTO Sessao (data_hora_inicio, user_id) OUTPUT INSERTED.sessao_id VALUES (@DataInicio, @UserId)";// data fim ignorada
			DateTime data = DateTime.Now;
			try {
				int id = await db.ExecuteScalar<dynamic>(sessionSQL, new {
					DataInicio = data,
					// DataFim = (DateTime?)null,
					UserId = dbUser.user_id
				});

				Session session = new Session();
				// session.data_hora_fim = (DateTime)(DateTime?)null; // ??????????????????????????????????????????????????????????????????????????????????
				session.data_hora_inicio = data;
				session.user_id = dbUser.user_id;
				session.sessao_id = id;

				// Console.WriteLine($"criada sessao para o user_id={dbUser.user_id} , session_id={session.sessao_id}");
				return session;
			} catch (System.NullReferenceException e) {
				return null;
			}
		}

		public async Task<User> createUser(User user) {
			const string userSQL = "INSERT INTO Utilizador (rua_fiscal, cidade_fiscal, codpostal_fiscal, rua_entrega, cidade_entrega, codpostal_entrega, foto, email, username, pass_hash, data_registo) OUTPUT INSERTED.user_id VALUES (@RuaF, @CidadeF, @CodF, @RuaE, @CidadeE, @CodE, @Foto, @Email, @Username, @Pass, @Data_reg)";

			try {
				int id = await db.ExecuteScalar<dynamic>(userSQL, new {
					RuaF = user.rua_fiscal,
					CidadeF = user.cidade_fiscal,
					CodF = user.codpostal_fiscal,
					RuaE = user.rua_entrega,
					CidadeE = user.cidade_entrega,
					CodE = user.codpostal_entrega,
					Foto = user.foto,
					Email = user.email,
					Username = user.username,
					Pass = user.pass_hash,
					Data_reg = user.data_registo
				});

				User dbUser = new User();
					dbUser.user_id = id;
					dbUser.rua_fiscal= user.rua_fiscal;
					dbUser.cidade_fiscal= user.cidade_fiscal;
					dbUser.codpostal_fiscal= user.codpostal_fiscal;
					dbUser.rua_entrega= user.rua_entrega;
					dbUser.cidade_entrega= user.cidade_entrega;
					dbUser.codpostal_entrega= user.codpostal_entrega;
					dbUser.foto= user.foto;
					dbUser.email= user.email;
					dbUser.username= user.username;
					dbUser.pass_hash= user.pass_hash;
					dbUser.data_registo= user.data_registo;

				// Console.WriteLine($"criada sessao para o user_id={dbUser.user_id} , session_id={session.sessao_id}");
				return dbUser;
			} catch (NullReferenceException) {
				return null;
			}
		}
	}
}
