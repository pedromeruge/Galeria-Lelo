using Classes.User;
using Classes.User;
using Classes.Session;

namespace DataLayer.UserService {
    public interface IUserService {
		Task<bool> checkUserValid(User user); // ve se email existe e se password bate certo (o resto por agora nao interessa)
		Task<bool> checkUserValidSession(User user, Session session); // ve se aquela session corresponde ao user, e se session ja acabou (se acabou, nao e valida). por agora session nao tem data de fim.
    } 
}
