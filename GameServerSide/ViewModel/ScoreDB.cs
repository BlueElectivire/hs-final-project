using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class ScoreDB : BaseDB
    {
        private static ScoreList scores = null;

        protected override BaseEntity NewEntity()
        {
            return new Score();
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Score score = entity as Score;

            score.Id = (int)rdr["id"];
            score.User = UserDB.SelectById((int)rdr["user"]);
            score.Level = (int)rdr["level"];
            score.Role = RoleDB.SelectById((int)rdr["role"]);
            score.Points = (int)rdr["points"];

            return score;
        }

        protected override void CreateInsert(BaseEntity entity, OleDbCommand cmd)
        {
            if (entity is Score score)
            { 
                cmd.CommandText = "INSERT INTO scoreTable ([user], [level], role, points) VALUES (@user, @level, @role, @points)";
                cmd.Parameters.Add(new OleDbParameter("@user", score.User.Id));
                cmd.Parameters.Add(new OleDbParameter("@level", score.Level));
                cmd.Parameters.Add(new OleDbParameter("@role", score.Role.Id));
                cmd.Parameters.Add(new OleDbParameter("@points", score.Points));
            }
        }
        protected override void CreateUpdate(BaseEntity entity, OleDbCommand cmd)
        {
            if (entity is Score score)
            {
                cmd.CommandText = "UPDATE scoreTable SET user = @user, level = @level, role = @role, points = @points WHERE id = @id";
                cmd.Parameters.Add(new OleDbParameter("@user", score.User.Id));
                cmd.Parameters.Add(new OleDbParameter("@level", score.Level));
                cmd.Parameters.Add(new OleDbParameter("@role", score.Role.Id));
                cmd.Parameters.Add(new OleDbParameter("@points", score.Points));
                cmd.Parameters.Add(new OleDbParameter("@id", score.Id));
            }
        }
        protected override void CreateDelete(BaseEntity entity, OleDbCommand cmd)
        {
            if (entity is Score score)
            {
                cmd.CommandText = "DELETE * FROM scoreTable WHERE id = @id";
                cmd.Parameters.Add(new OleDbParameter("@id", score.Id));
            }
        }

        public ScoreList SelectAll()
        {
            cmd.CommandText = "SELECT * FROM scoreTable";
            scores = new ScoreList(Select());

            return scores;
        }
        public static Score SelectById(int id)
        {
            if (scores == null)
            {
                ScoreDB db = new ScoreDB();
                db.SelectAll();
            }

            return scores.Find(item => item.Id == id);
        }
        public static ScoreList SelectByUser(User user)
        {
            if (scores == null)
            {
                ScoreDB db = new ScoreDB();
                db.SelectAll();
            }

            return new ScoreList(scores.FindAll(item => item.User.Id == user.Id));
        }
        public static ScoreList SelectBylevel(int level)
        {
            if (scores == null)
            {
                ScoreDB db = new ScoreDB();
                db.SelectAll();
            }

            return new ScoreList(scores.FindAll(item => item.Level == level));
        }
        public static ScoreList SelectByRole(Role role)
        {
            if (scores == null)
            {
                ScoreDB db = new ScoreDB();
                db.SelectAll();
            }

            return new ScoreList(scores.FindAll(item => item.Role.Id == role.Id));
        }
    }
}
