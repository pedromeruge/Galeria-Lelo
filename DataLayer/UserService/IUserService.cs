using Classes.User;
using Classes.Session;

namespace DataLayer.UserService {
    public interface IUserService {
		Task<User> getUser(string email);
		Task<bool> checkUserValid(User user); // ve se email existe e se password bate certo (o resto por agora nao interessa)
		Task<bool> checkUserValidSession(User user, Session session); // ve se aquela session corresponde ao user, e se session ja acabou (se acabou, nao e valida). por agora session nao tem data de fim.
		Task<Session> createSessionFor(User user); // nao faz absolutamente nenhum check. vai a BD buscar o user completo, so para ter a certeza
		Task<User> createUser(User user); // nao faz nenhum check
	}
}
