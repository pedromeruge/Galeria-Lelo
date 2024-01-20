using Classes.Admin;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace DataLayer.AdminService {

    public class AdminService : IAdminService {
		private ISqlDataAccess db;

		public AdminService(ISqlDataAccess data)
        {
            db = data;
        }

		public async Task<Admin> getAdmin(string email) {
			const string adminSQL = "SELECT admin_id, email, pass_hash FROM Administrador WHERE email = @Email";
			List<Admin> userList = await db.LoadData<Admin, dynamic>(adminSQL, new { Email = email });
			if (userList.Count > 0)
			{
				Admin user = userList[0];
				return user;
			} else {
				return null;
			}
		}

		public async Task<bool> checkAdminValid(Admin admin) {
			Admin dbAdmin = await getAdmin(admin.email);
			if (dbAdmin != null && admin.pass_hash == dbAdmin.pass_hash) {
				return true;
			}
			return false;
		}
	}
}
