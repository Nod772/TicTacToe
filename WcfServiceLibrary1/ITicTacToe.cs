using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract(CallbackContract =typeof(ICallback))]
    public interface ITicTacToe
    {
        [OperationContract]
        void MakeMove(int idSession, int currentid, Field field, char symb);
        [OperationContract]
        int CreateUser(string Name);
       
        [OperationContract]
        void StartGame(int id1,int id2);
          // TODO: Добавьте здесь операции служб
    }

    // Используйте контракт данных, как показано на следующем примере, чтобы добавить сложные типы к сервисным операциям.
    // В проект можно добавлять XSD-файлы. После построения проекта вы можете напрямую использовать в нем определенные типы данных с пространством имен "WcfServiceLibrary1.ContractType".
    public interface ICallback
    {
        [OperationContract]
        int Move(Field field, char symbol);
        [OperationContract]
        bool Action(bool action);
        [OperationContract]
        string YouWinner(bool result);
        [OperationContract]
        int GetIDSession(int idsession);
    }

}
