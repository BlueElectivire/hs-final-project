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

    [ServiceContract]
    public interface IGameService
    {
        //BaseDB Methods

        [OperationContract]
        bool InsertUser(User user);
        [OperationContract]
        bool InsertScore(Score score);
        [OperationContract]
        void Update(User user);
        [OperationContract]
        void Delete(User user);
        [OperationContract]
        int SaveChanges();

        //UserDB Methods

        [OperationContract]
        UserList GetAllUsers();
        [OperationContract]
        User GetUserById(int id);
        [OperationContract]
        User GetUserByUsername(string username);

        //RoleDB Methods

        [OperationContract]
        RoleList GetAllRoles();
        [OperationContract]
        Role GetRoleById(int id);
        [OperationContract]
        Role GetRoleByType(string type);

        //ScoreDB Methods

        [OperationContract]
        ScoreList GetAllScores();
        [OperationContract]
        Score GetScoreById(int id);
        [OperationContract]
        ScoreList GetScoresByUser(User user);
        [OperationContract]
        ScoreList GetScoresByRole(Role role);

        //Game Methods

        [OperationContract]
        int NewGame(User user, int level, Role role, int points);
    }
}
