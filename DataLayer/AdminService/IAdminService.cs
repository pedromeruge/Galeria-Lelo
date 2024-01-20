using Classes.Admin;

namespace DataLayer.AdminService {
    public interface IAdminService {
		Task<Admin> getAdmin(string email);
		Task<bool> checkAdminValid(Admin admin); // ve se email existe e se password bate certo (o resto por agora nao interessa)
	}
}
