using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model;
using ViewModel;

namespace GameServiceLibrary
{
    public class GameService : IGameService
    {

        //BaseDB Methods

        public bool InsertUser(User user)
        {
            try
            {
                UserDB udb = new UserDB();
                udb.Insert(user);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool InsertScore(Score score)
        {
            try
            {
                ScoreDB sdb = new ScoreDB();
                sdb.Insert(score);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void Update(User user)
        {
            UserDB udb = new UserDB();
            udb.Update(user);
        }
        
        public void Delete(User user)
        {
            UserDB udb = new UserDB();
            udb.Delete(user);
        }
        
        public int SaveChanges()
        {
            UserDB db = new UserDB();
            return db.SaveChanges();
        }

        //UserDB Methods

        public UserList GetAllUsers()
        {
            UserDB db = new UserDB();
            return db.SelectAll();
        }
        
        public User GetUserById(int id)
        {
            return UserDB.SelectById(id);
        }
        
        public User GetUserByUsername(string username)
        {
            return UserDB.SelectByUsername(username);
        }

        //RoleDB Methods

        public RoleList GetAllRoles()
        {
            RoleDB db = new RoleDB();
            return db.SelectAll();
        }
        
        public Role GetRoleById(int id)
        {
            return RoleDB.SelectById(id);
        }
        
        public Role GetRoleByType(string type)
        {
            return RoleDB.SelectByType(type);
        }

        //ScoreDB Methods

        public ScoreList GetAllScores()
        {
            ScoreDB db = new ScoreDB();
            return db.SelectAll();
        }
        
        public Score GetScoreById(int id)
        {
            return ScoreDB.SelectById(id);
        }
        
        public ScoreList GetScoresByUser(User user)
        {
            return ScoreDB.SelectByUser(user);
        }
        
        public ScoreList GetScoresByRole(Role role)
        {
            return ScoreDB.SelectByRole(role);
        }

        //Game Methods
        public int NewGame(User user, int level, Role role, int points)
        {
            Score score = new Score()
            {
                User = user,
                Level = level,
                Role = role,
                Points = points,
            };

            ScoreDB sdb = new ScoreDB();
            sdb.Insert(score);
            return sdb.SaveChanges();
        }
    }
}
