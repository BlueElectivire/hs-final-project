using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class RoleDB : BaseDB
    {
        private static RoleList roles = null;

        protected override BaseEntity NewEntity()
        {
            return new Role();
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Role role = entity as Role;

            role.Id = (int)rdr["id"];
            role.Type = rdr["type"].ToString();

            return role;
        }

        protected override void CreateInsert(BaseEntity entity, OleDbCommand cmd)
        {
            if (entity is Role role)
            {
                cmd.CommandText = "INSERT INTO roleTable SET type = @type";
                cmd.Parameters.Add(new OleDbParameter("@level", role.Type));
            }
        }
        protected override void CreateUpdate(BaseEntity entity, OleDbCommand cmd)
        {
            if (entity is Role role)
            {
                cmd.CommandText = "INSERT INTO roleTable SET type = @type WHERE id = @id";
                cmd.Parameters.Add(new OleDbParameter("@level", role.Type));
                cmd.Parameters.Add(new OleDbParameter("@id", role.Id));
            }
        }
        protected override void CreateDelete(BaseEntity entity, OleDbCommand cmd)
        {
            if (entity is Role role)
            {
                cmd.CommandText = "DELETE * FROM roleTable WHERE id = @id";
                cmd.Parameters.Add(new OleDbParameter("@id", role.Id));
            }
        }

        public RoleList SelectAll()
        {
            cmd.CommandText = "SELECT * FROM roleTable";
            roles = new RoleList(Select());

            return roles;
        }
        public static Role SelectById(int id)
        {
            if (roles == null)
            {
                RoleDB db = new RoleDB();
                db.SelectAll();
            }

            return roles.Find(item => item.Id == id);
        }
        public static Role SelectByType(string type)
        {
            if (roles == null)
            {
                RoleDB db = new RoleDB();
                db.SelectAll();
            }

            return roles.Find(item => item.Type == type);
        }
    }
}
