using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class UserDB : BaseDB
    {
        private static UserList users = null;

        protected override BaseEntity NewEntity()
        {
            return new User();
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            User user = entity as User;

            user.Id = (int)rdr["id"];
            user.Username = rdr["username"].ToString();
            user.Password = rdr["password"].ToString();
            user.Mail = rdr["mail"].ToString();
            user.IsAdmin = (bool)rdr["isAdmin"];

            return user;
        }

        protected override void CreateInsert(BaseEntity entity, OleDbCommand cmd)
        {
            if (entity is User user)
            {
                cmd.CommandText = "INSERT INTO userTable (username, [password], mail, isAdmin) VALUES (@username, @password, @mail, @isAdmin)";
                cmd.Parameters.Add(new OleDbParameter("@username", user.Username));
                cmd.Parameters.Add(new OleDbParameter("@password", user.Password));
                cmd.Parameters.Add(new OleDbParameter("@mail", user.Mail));
                cmd.Parameters.Add(new OleDbParameter("@isAdmin", user.IsAdmin));
            }
        }
        protected override void CreateUpdate(BaseEntity entity, OleDbCommand cmd)
        {
            if (entity is User user)
            {
                cmd.CommandText = "UPDATE userTable SET username = @username, [password] = @password, mail = @mail, isAdmin = @isAdmin WHERE id = @id";
                cmd.Parameters.Add(new OleDbParameter("@username", user.Username));
                cmd.Parameters.Add(new OleDbParameter("@password", user.Password));
                cmd.Parameters.Add(new OleDbParameter("@mail", user.Mail));
                cmd.Parameters.Add(new OleDbParameter("@isAdmin", user.IsAdmin));
                cmd.Parameters.Add(new OleDbParameter("@id", user.Id));
            }
        }
        protected override void CreateDelete(BaseEntity entity, OleDbCommand cmd)
        {
            if (entity is User user)
            {
                cmd.CommandText = "DELETE * FROM userTable WHERE id = @id";
                cmd.Parameters.Add(new OleDbParameter("@id", user.Id));
            }
        }

        public UserList SelectAll()
        {
            cmd.CommandText = "SELECT * FROM userTable";
            users = new UserList(Select());

            return users;
        }
        public static User SelectById(int id)
        {
            if (users == null)
            {
                UserDB db = new UserDB();
                db.SelectAll();
            }

            return users.Find(item => item.Id == id);
        }
        public static User SelectByUsername(string username)
        {
            if (users == null)
            {
                UserDB db = new UserDB();
                db.SelectAll();
            }

            return users.Find(item => item.Username == username);
        }
    }
}
