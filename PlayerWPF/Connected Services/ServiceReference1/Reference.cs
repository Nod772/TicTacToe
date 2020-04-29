﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PlayerWPF.ServiceReference1 {
    using System.Runtime.Serialization;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Field", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceLibrary1")]
    public enum Field : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        A1 = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        A2 = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        A3 = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        B1 = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        B2 = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        B3 = 5,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        C1 = 6,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        C2 = 7,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        C3 = 8,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.ITicTacToe", CallbackContract=typeof(PlayerWPF.ServiceReference1.ITicTacToeCallback))]
    public interface ITicTacToe {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicTacToe/MakeMove", ReplyAction="http://tempuri.org/ITicTacToe/MakeMoveResponse")]
        void MakeMove(int idSession, int currentid, PlayerWPF.ServiceReference1.Field field, char symb);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicTacToe/MakeMove", ReplyAction="http://tempuri.org/ITicTacToe/MakeMoveResponse")]
        System.Threading.Tasks.Task MakeMoveAsync(int idSession, int currentid, PlayerWPF.ServiceReference1.Field field, char symb);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicTacToe/CreateUser", ReplyAction="http://tempuri.org/ITicTacToe/CreateUserResponse")]
        int CreateUser(string Name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicTacToe/CreateUser", ReplyAction="http://tempuri.org/ITicTacToe/CreateUserResponse")]
        System.Threading.Tasks.Task<int> CreateUserAsync(string Name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicTacToe/StartGame", ReplyAction="http://tempuri.org/ITicTacToe/StartGameResponse")]
        void StartGame(int id1, int id2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicTacToe/StartGame", ReplyAction="http://tempuri.org/ITicTacToe/StartGameResponse")]
        System.Threading.Tasks.Task StartGameAsync(int id1, int id2);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITicTacToeCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicTacToe/Move", ReplyAction="http://tempuri.org/ITicTacToe/MoveResponse")]
        int Move(PlayerWPF.ServiceReference1.Field field, char symbol);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicTacToe/Action", ReplyAction="http://tempuri.org/ITicTacToe/ActionResponse")]
        bool Action([System.ServiceModel.MessageParameterAttribute(Name="action")] bool action1);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicTacToe/YouWinner", ReplyAction="http://tempuri.org/ITicTacToe/YouWinnerResponse")]
        string YouWinner(bool result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITicTacToe/GetIDSession", ReplyAction="http://tempuri.org/ITicTacToe/GetIDSessionResponse")]
        int GetIDSession(int idsession);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITicTacToeChannel : PlayerWPF.ServiceReference1.ITicTacToe, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TicTacToeClient : System.ServiceModel.DuplexClientBase<PlayerWPF.ServiceReference1.ITicTacToe>, PlayerWPF.ServiceReference1.ITicTacToe {
        
        public TicTacToeClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public TicTacToeClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public TicTacToeClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public TicTacToeClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public TicTacToeClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void MakeMove(int idSession, int currentid, PlayerWPF.ServiceReference1.Field field, char symb) {
            base.Channel.MakeMove(idSession, currentid, field, symb);
        }
        
        public System.Threading.Tasks.Task MakeMoveAsync(int idSession, int currentid, PlayerWPF.ServiceReference1.Field field, char symb) {
            return base.Channel.MakeMoveAsync(idSession, currentid, field, symb);
        }
        
        public int CreateUser(string Name) {
            return base.Channel.CreateUser(Name);
        }
        
        public System.Threading.Tasks.Task<int> CreateUserAsync(string Name) {
            return base.Channel.CreateUserAsync(Name);
        }
        
        public void StartGame(int id1, int id2) {
            base.Channel.StartGame(id1, id2);
        }
        
        public System.Threading.Tasks.Task StartGameAsync(int id1, int id2) {
            return base.Channel.StartGameAsync(id1, id2);
        }
    }
}
