﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Interface.GameService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BaseEntity", Namespace="http://schemas.datacontract.org/2004/07/Model")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Interface.GameService.Score))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Interface.GameService.Role))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Interface.GameService.User))]
    public partial class BaseEntity : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Score", Namespace="http://schemas.datacontract.org/2004/07/Model")]
    [System.SerializableAttribute()]
    public partial class Score : Interface.GameService.BaseEntity {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int LevelField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PointsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Interface.GameService.Role RoleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Interface.GameService.User UserField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Level {
            get {
                return this.LevelField;
            }
            set {
                if ((this.LevelField.Equals(value) != true)) {
                    this.LevelField = value;
                    this.RaisePropertyChanged("Level");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Points {
            get {
                return this.PointsField;
            }
            set {
                if ((this.PointsField.Equals(value) != true)) {
                    this.PointsField = value;
                    this.RaisePropertyChanged("Points");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Interface.GameService.Role Role {
            get {
                return this.RoleField;
            }
            set {
                if ((object.ReferenceEquals(this.RoleField, value) != true)) {
                    this.RoleField = value;
                    this.RaisePropertyChanged("Role");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Interface.GameService.User User {
            get {
                return this.UserField;
            }
            set {
                if ((object.ReferenceEquals(this.UserField, value) != true)) {
                    this.UserField = value;
                    this.RaisePropertyChanged("User");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Role", Namespace="http://schemas.datacontract.org/2004/07/Model")]
    [System.SerializableAttribute()]
    public partial class Role : Interface.GameService.BaseEntity {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TypeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Type {
            get {
                return this.TypeField;
            }
            set {
                if ((object.ReferenceEquals(this.TypeField, value) != true)) {
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/Model")]
    [System.SerializableAttribute()]
    public partial class User : Interface.GameService.BaseEntity {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsAdminField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsernameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsAdmin {
            get {
                return this.IsAdminField;
            }
            set {
                if ((this.IsAdminField.Equals(value) != true)) {
                    this.IsAdminField = value;
                    this.RaisePropertyChanged("IsAdmin");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Mail {
            get {
                return this.MailField;
            }
            set {
                if ((object.ReferenceEquals(this.MailField, value) != true)) {
                    this.MailField = value;
                    this.RaisePropertyChanged("Mail");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Username {
            get {
                return this.UsernameField;
            }
            set {
                if ((object.ReferenceEquals(this.UsernameField, value) != true)) {
                    this.UsernameField = value;
                    this.RaisePropertyChanged("Username");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="UserList", Namespace="http://schemas.datacontract.org/2004/07/Model", ItemName="User")]
    [System.SerializableAttribute()]
    public class UserList : System.Collections.Generic.List<Interface.GameService.User> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="RoleList", Namespace="http://schemas.datacontract.org/2004/07/Model", ItemName="Role")]
    [System.SerializableAttribute()]
    public class RoleList : System.Collections.Generic.List<Interface.GameService.Role> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ScoreList", Namespace="http://schemas.datacontract.org/2004/07/Model", ItemName="Score")]
    [System.SerializableAttribute()]
    public class ScoreList : System.Collections.Generic.List<Interface.GameService.Score> {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="GameService.IGameService")]
    public interface IGameService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/InsertUser", ReplyAction="http://tempuri.org/IGameService/InsertUserResponse")]
        bool InsertUser(Interface.GameService.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/InsertUser", ReplyAction="http://tempuri.org/IGameService/InsertUserResponse")]
        System.Threading.Tasks.Task<bool> InsertUserAsync(Interface.GameService.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/InsertScore", ReplyAction="http://tempuri.org/IGameService/InsertScoreResponse")]
        bool InsertScore(Interface.GameService.Score score);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/InsertScore", ReplyAction="http://tempuri.org/IGameService/InsertScoreResponse")]
        System.Threading.Tasks.Task<bool> InsertScoreAsync(Interface.GameService.Score score);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/Update", ReplyAction="http://tempuri.org/IGameService/UpdateResponse")]
        void Update(Interface.GameService.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/Update", ReplyAction="http://tempuri.org/IGameService/UpdateResponse")]
        System.Threading.Tasks.Task UpdateAsync(Interface.GameService.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/Delete", ReplyAction="http://tempuri.org/IGameService/DeleteResponse")]
        void Delete(Interface.GameService.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/Delete", ReplyAction="http://tempuri.org/IGameService/DeleteResponse")]
        System.Threading.Tasks.Task DeleteAsync(Interface.GameService.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/SaveChanges", ReplyAction="http://tempuri.org/IGameService/SaveChangesResponse")]
        int SaveChanges();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/SaveChanges", ReplyAction="http://tempuri.org/IGameService/SaveChangesResponse")]
        System.Threading.Tasks.Task<int> SaveChangesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/GetAllUsers", ReplyAction="http://tempuri.org/IGameService/GetAllUsersResponse")]
        Interface.GameService.UserList GetAllUsers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/GetAllUsers", ReplyAction="http://tempuri.org/IGameService/GetAllUsersResponse")]
        System.Threading.Tasks.Task<Interface.GameService.UserList> GetAllUsersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/GetUserById", ReplyAction="http://tempuri.org/IGameService/GetUserByIdResponse")]
        Interface.GameService.User GetUserById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/GetUserById", ReplyAction="http://tempuri.org/IGameService/GetUserByIdResponse")]
        System.Threading.Tasks.Task<Interface.GameService.User> GetUserByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/GetUserByUsername", ReplyAction="http://tempuri.org/IGameService/GetUserByUsernameResponse")]
        Interface.GameService.User GetUserByUsername(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/GetUserByUsername", ReplyAction="http://tempuri.org/IGameService/GetUserByUsernameResponse")]
        System.Threading.Tasks.Task<Interface.GameService.User> GetUserByUsernameAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/GetAllRoles", ReplyAction="http://tempuri.org/IGameService/GetAllRolesResponse")]
        Interface.GameService.RoleList GetAllRoles();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/GetAllRoles", ReplyAction="http://tempuri.org/IGameService/GetAllRolesResponse")]
        System.Threading.Tasks.Task<Interface.GameService.RoleList> GetAllRolesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/GetRoleById", ReplyAction="http://tempuri.org/IGameService/GetRoleByIdResponse")]
        Interface.GameService.Role GetRoleById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/GetRoleById", ReplyAction="http://tempuri.org/IGameService/GetRoleByIdResponse")]
        System.Threading.Tasks.Task<Interface.GameService.Role> GetRoleByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/GetRoleByType", ReplyAction="http://tempuri.org/IGameService/GetRoleByTypeResponse")]
        Interface.GameService.Role GetRoleByType(string type);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/GetRoleByType", ReplyAction="http://tempuri.org/IGameService/GetRoleByTypeResponse")]
        System.Threading.Tasks.Task<Interface.GameService.Role> GetRoleByTypeAsync(string type);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/GetAllScores", ReplyAction="http://tempuri.org/IGameService/GetAllScoresResponse")]
        Interface.GameService.ScoreList GetAllScores();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/GetAllScores", ReplyAction="http://tempuri.org/IGameService/GetAllScoresResponse")]
        System.Threading.Tasks.Task<Interface.GameService.ScoreList> GetAllScoresAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/GetScoreById", ReplyAction="http://tempuri.org/IGameService/GetScoreByIdResponse")]
        Interface.GameService.Score GetScoreById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/GetScoreById", ReplyAction="http://tempuri.org/IGameService/GetScoreByIdResponse")]
        System.Threading.Tasks.Task<Interface.GameService.Score> GetScoreByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/GetScoresByUser", ReplyAction="http://tempuri.org/IGameService/GetScoresByUserResponse")]
        Interface.GameService.ScoreList GetScoresByUser(Interface.GameService.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/GetScoresByUser", ReplyAction="http://tempuri.org/IGameService/GetScoresByUserResponse")]
        System.Threading.Tasks.Task<Interface.GameService.ScoreList> GetScoresByUserAsync(Interface.GameService.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/GetScoresByRole", ReplyAction="http://tempuri.org/IGameService/GetScoresByRoleResponse")]
        Interface.GameService.ScoreList GetScoresByRole(Interface.GameService.Role role);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/GetScoresByRole", ReplyAction="http://tempuri.org/IGameService/GetScoresByRoleResponse")]
        System.Threading.Tasks.Task<Interface.GameService.ScoreList> GetScoresByRoleAsync(Interface.GameService.Role role);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/NewGame", ReplyAction="http://tempuri.org/IGameService/NewGameResponse")]
        int NewGame(Interface.GameService.User user, int level, Interface.GameService.Role role, int points);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/NewGame", ReplyAction="http://tempuri.org/IGameService/NewGameResponse")]
        System.Threading.Tasks.Task<int> NewGameAsync(Interface.GameService.User user, int level, Interface.GameService.Role role, int points);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGameServiceChannel : Interface.GameService.IGameService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GameServiceClient : System.ServiceModel.ClientBase<Interface.GameService.IGameService>, Interface.GameService.IGameService {
        
        public GameServiceClient() {
        }
        
        public GameServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GameServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GameServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GameServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool InsertUser(Interface.GameService.User user) {
            return base.Channel.InsertUser(user);
        }
        
        public System.Threading.Tasks.Task<bool> InsertUserAsync(Interface.GameService.User user) {
            return base.Channel.InsertUserAsync(user);
        }
        
        public bool InsertScore(Interface.GameService.Score score) {
            return base.Channel.InsertScore(score);
        }
        
        public System.Threading.Tasks.Task<bool> InsertScoreAsync(Interface.GameService.Score score) {
            return base.Channel.InsertScoreAsync(score);
        }
        
        public void Update(Interface.GameService.User user) {
            base.Channel.Update(user);
        }
        
        public System.Threading.Tasks.Task UpdateAsync(Interface.GameService.User user) {
            return base.Channel.UpdateAsync(user);
        }
        
        public void Delete(Interface.GameService.User user) {
            base.Channel.Delete(user);
        }
        
        public System.Threading.Tasks.Task DeleteAsync(Interface.GameService.User user) {
            return base.Channel.DeleteAsync(user);
        }
        
        public int SaveChanges() {
            return base.Channel.SaveChanges();
        }
        
        public System.Threading.Tasks.Task<int> SaveChangesAsync() {
            return base.Channel.SaveChangesAsync();
        }
        
        public Interface.GameService.UserList GetAllUsers() {
            return base.Channel.GetAllUsers();
        }
        
        public System.Threading.Tasks.Task<Interface.GameService.UserList> GetAllUsersAsync() {
            return base.Channel.GetAllUsersAsync();
        }
        
        public Interface.GameService.User GetUserById(int id) {
            return base.Channel.GetUserById(id);
        }
        
        public System.Threading.Tasks.Task<Interface.GameService.User> GetUserByIdAsync(int id) {
            return base.Channel.GetUserByIdAsync(id);
        }
        
        public Interface.GameService.User GetUserByUsername(string username) {
            return base.Channel.GetUserByUsername(username);
        }
        
        public System.Threading.Tasks.Task<Interface.GameService.User> GetUserByUsernameAsync(string username) {
            return base.Channel.GetUserByUsernameAsync(username);
        }
        
        public Interface.GameService.RoleList GetAllRoles() {
            return base.Channel.GetAllRoles();
        }
        
        public System.Threading.Tasks.Task<Interface.GameService.RoleList> GetAllRolesAsync() {
            return base.Channel.GetAllRolesAsync();
        }
        
        public Interface.GameService.Role GetRoleById(int id) {
            return base.Channel.GetRoleById(id);
        }
        
        public System.Threading.Tasks.Task<Interface.GameService.Role> GetRoleByIdAsync(int id) {
            return base.Channel.GetRoleByIdAsync(id);
        }
        
        public Interface.GameService.Role GetRoleByType(string type) {
            return base.Channel.GetRoleByType(type);
        }
        
        public System.Threading.Tasks.Task<Interface.GameService.Role> GetRoleByTypeAsync(string type) {
            return base.Channel.GetRoleByTypeAsync(type);
        }
        
        public Interface.GameService.ScoreList GetAllScores() {
            return base.Channel.GetAllScores();
        }
        
        public System.Threading.Tasks.Task<Interface.GameService.ScoreList> GetAllScoresAsync() {
            return base.Channel.GetAllScoresAsync();
        }
        
        public Interface.GameService.Score GetScoreById(int id) {
            return base.Channel.GetScoreById(id);
        }
        
        public System.Threading.Tasks.Task<Interface.GameService.Score> GetScoreByIdAsync(int id) {
            return base.Channel.GetScoreByIdAsync(id);
        }
        
        public Interface.GameService.ScoreList GetScoresByUser(Interface.GameService.User user) {
            return base.Channel.GetScoresByUser(user);
        }
        
        public System.Threading.Tasks.Task<Interface.GameService.ScoreList> GetScoresByUserAsync(Interface.GameService.User user) {
            return base.Channel.GetScoresByUserAsync(user);
        }
        
        public Interface.GameService.ScoreList GetScoresByRole(Interface.GameService.Role role) {
            return base.Channel.GetScoresByRole(role);
        }
        
        public System.Threading.Tasks.Task<Interface.GameService.ScoreList> GetScoresByRoleAsync(Interface.GameService.Role role) {
            return base.Channel.GetScoresByRoleAsync(role);
        }
        
        public int NewGame(Interface.GameService.User user, int level, Interface.GameService.Role role, int points) {
            return base.Channel.NewGame(user, level, role, points);
        }
        
        public System.Threading.Tasks.Task<int> NewGameAsync(Interface.GameService.User user, int level, Interface.GameService.Role role, int points) {
            return base.Channel.NewGameAsync(user, level, role, points);
        }
    }
}