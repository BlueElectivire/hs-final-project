using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.OleDb;

namespace ViewModel
{
    public abstract class BaseDB
    {
        private readonly string conStr;
        protected OleDbConnection con;
        protected OleDbCommand cmd;
        protected OleDbDataReader rdr;

        protected static List<ChangeEntity> insert = new List<ChangeEntity>();
        protected static List<ChangeEntity> update = new List<ChangeEntity>();
        protected static List<ChangeEntity> delete = new List<ChangeEntity>();

        protected abstract void CreateInsert(BaseEntity entity, OleDbCommand cmd);
        protected abstract void CreateUpdate(BaseEntity entity, OleDbCommand cmd);
        protected abstract void CreateDelete(BaseEntity entity, OleDbCommand cmd);

        protected abstract BaseEntity NewEntity();

        protected abstract BaseEntity CreateModel(BaseEntity entity);

        public BaseDB()
        {
            conStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='..\..\..\ViewModel\database.accdb';Persist Security Info=True";
            con = new OleDbConnection(conStr);
            cmd = new OleDbCommand();
        }

        protected List<BaseEntity> Select()
        {
            List<BaseEntity> list = new List<BaseEntity>();

            try
            {
                cmd.Connection = con;
                con.Open();
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    BaseEntity entity = NewEntity();
                    list.Add(CreateModel(entity));
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            finally
            {
                if (rdr != null)
                    rdr.Close();
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

            return list;
        }

        public virtual void Insert(BaseEntity entity)
        {
            BaseEntity reqEnt = NewEntity();
            if (entity != null && entity.GetType() == reqEnt.GetType())
                insert.Add(new ChangeEntity(entity, CreateInsert));
        }
        public virtual void Delete(BaseEntity entity)
        {
            BaseEntity reqEnt = NewEntity();
            if (entity != null && entity.GetType() == reqEnt.GetType())
                delete.Add(new ChangeEntity(entity, CreateDelete));
        }
        public virtual void Update(BaseEntity entity)
        {
            BaseEntity reqEnt = NewEntity();
            if (entity != null && entity.GetType() == reqEnt.GetType())
                update.Add(new ChangeEntity(entity, CreateUpdate));
        }
        public int SaveChanges()
        {
            int affect = 0;

            try
            {
                cmd.Connection = con;
                con.Open();

                foreach (var entity in insert)
                {
                    cmd.Parameters.Clear();
                    entity.Create(entity.Entity, cmd);
                    affect += cmd.ExecuteNonQuery();
                }
                insert.Clear();

                foreach (var entity in update)
                {
                    cmd.Parameters.Clear();
                    entity.Create(entity.Entity, cmd);
                    affect += cmd.ExecuteNonQuery();
                }
                update.Clear();

                foreach (var entity in delete)
                {
                    cmd.Parameters.Clear();
                    entity.Create(entity.Entity, cmd);
                    affect += cmd.ExecuteNonQuery();
                }
                delete.Clear();
            }
            catch (Exception e)
            { 
                System.Diagnostics.Debug.WriteLine(e.Message + "\nSQL: " + cmd.CommandText);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return affect;
        }
    }
}
