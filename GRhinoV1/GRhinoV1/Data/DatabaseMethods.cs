using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GRhinoV1.Data;
using GRhinoV1.Model;
using System.Linq;
using SQLite;
using System.Linq.Expressions;
namespace GRhinoV1.Data
{
	public static class DatabaseMethods
	{

		//Custom Any implementations due to lack of method in SQLite
		public static bool Any(this AsyncTableQuery<User> res) => res.FirstOrDefaultAsync().Result != null;
		public static bool Any(this AsyncTableQuery<User> table, Expression<Func<User, bool>> predExpr) => table.Where(predExpr).Any();

		public static int InsertUser(this Database db, User u) => u.ID != 0 ?  db.db.UpdateAsync(u).Result : db.db.InsertAsync(u).Result; //.Result converts from Task<int> to int whilst maintaining asynchronous
		public static bool UserExists(this Database db, int userId) => db.db.Table<User>().Any(u => u.ID == userId);
		public static bool EmailRegistered(this Database db, string email) => db.db.Table<User>().Any(u => u.Email == email);
		public static User GetUser(this Database db, int userId) => db.db.Table<User>().Where(u => u.ID == userId).FirstOrDefaultAsync().Result;
		public static User GetUser(this Database db, string email) => db.db.Table<User>().Where(u => u.Email == email).FirstOrDefaultAsync().Result;

	}
}
