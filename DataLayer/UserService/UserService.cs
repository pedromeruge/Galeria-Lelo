using Classes.User;
using Classes.Session;

namespace DataLayer.UserService {

    public class UserService : IUserService {
		private ISqlDataAccess db;

		public UserService(ISqlDataAccess data)
        {
            db = data;
        }

		private async Task<User> getUser(string email) {
			const string userSQL = "SELECT user_id, rua_fiscal, cidade_fiscal, codpostal_fiscal, rua_entrega, cidade_entrega, codpostal_entrega, foto, email, username, pass_hash, data_registo FROM Utilizador WHERE email = @Email";
			List<User> userList = await db.LoadData<User, dynamic>(userSQL, new { Email = email });
			if (userList.Count > 0)
			{
				User user = userList[0];
				Console.WriteLine("Encontrado user");
				Console.WriteLine(user.username);
				return user;
			} else {
				// throw new InvalidOperationException();
				Console.WriteLine("User nao existe");
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

    }
}