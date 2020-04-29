using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class TicTacToe : ITicTacToe
    {
        List<User> users = new List<User>();
        List<GameSession> sessions = new List<GameSession>();

        static int idUser = 0;
        static int idSession = 0;

        User p1 = new User();
        User p2 = new User();


        public int CreateUser(string name)
        {
            idUser++;
            User user = new User { ID = idUser, callback = OperationContext.Current.GetCallbackChannel<ICallback>(), Name = name, Score = 0 };
            users.Add(user);
            return user.ID;
        }


        public void MakeMove(int idSession, int currentUser, Field field, char symb)
        {
            GameSession current = sessions.FirstOrDefault(x => x.IDSession == idSession);
            #region MyRegion

            //if (currentUser == p1.ID)
            //{
            //    p2.callback.Move(field, symb);
            //    p1.callback.Move(field, symb);
            //    p1.action = false;
            //    p2.action = true;
            //    p1.callback.Action(p1.action);
            //    p2.callback.Action(p2.action);



            //}
            //else
            //{
            //    p1.callback.Move(field, symb);
            //    p2.callback.Move(field, symb);
            //    p1.action = true;
            //    p2.action = false;
            //    p1.callback.Action(p1.action);
            //    p2.callback.Action(p2.action);
            //}
            #endregion

            if (currentUser == current.player1.ID)
            {

                FieldServer selectionField = current.Arena.Filds.FirstOrDefault(x => x.field == field);
                selectionField.symbol = symb;



                current.player1.callback.Move(field, symb);
                current.player2.callback.Move(field, symb);



                current.player1.action = false;
                current.player2.action = true;

                current.player2.callback.Action(current.player2.action);
                current.player1.callback.Action(current.player1.action);

                if (current.Arena.CheckFilds(symb))
                {
                    current.player1.callback.YouWinner(true);
                    current.player2.callback.YouWinner(false);

                    sessions.Remove(current);

                }
            }
            else
            {
                FieldServer selectionField = current.Arena.Filds.FirstOrDefault(x => x.field == field);
                selectionField.symbol = symb;



                current.player2.callback.Move(field, symb);
                current.player1.callback.Move(field, symb);


                current.player2.action = false;
                current.player1.action = true;


                current.player2.callback.Action(current.player2.action);
                current.player1.callback.Action(current.player1.action);

                if (current.Arena.CheckFilds(symb))
                {
                    current.player2.callback.YouWinner(true);
                    current.player1.callback.YouWinner(false);

                    sessions.Remove(current);

                }
            }
        }

        public void StartGame(int firstid, int secondid)
        {
            GameSession session = new GameSession { Arena = new GameArena(), IDSession = idSession };

            foreach (User item in users)
            {
                if (item.ID == firstid)
                {
                    session.player1 = new User();
                    session.player1.ID = firstid;
                    session.player1 = item;
                }
                if (item.ID == secondid)
                {
                    session.player2 = new User();
                    session.player2.ID = secondid;
                    session.player2 = item;
                }
            }

            sessions.Add(session);


            session.player1.action = true;
            session.player2.action = false;

            session.player1.callback.Action(session.player1.action);
            session.player2.callback.Action(session.player2.action);

            session.player1.callback.GetIDSession(session.IDSession);
            session.player2.callback.GetIDSession(session.IDSession);


        }


    }
    class User
    {
        public int ID { get; set; }
        public ICallback callback { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public char Symbol { get; set; }
        public bool action;
    }
    class GameSession
    {
        public int IDSession { get; set; }
        public GameArena Arena { get; set; }
        public User player1 { get; set; }
        public User player2 { get; set; }

        public GameSession()
        {
            player1 = new User();
            player2 = new User();
            Arena = new GameArena();
        }

    }
    class GameArena
    {

        public List<FieldServer> Filds { get; set; }

        public GameArena()
        {
            Filds = new List<FieldServer> { A1, A2, A3, B1, B2, B3, C1, C2, C3 };
        }
        public string GetMemberName<T, TValue>(Expression<Func<T, TValue>> memberAccess)
        {
            return ((MemberExpression)memberAccess.Body).Member.Name;
        }

        public bool CheckFilds(char symbolCurrentUser)
        {
            if ((A1.symbol == A2.symbol) && (A2.symbol == A3.symbol) && (A3.symbol == symbolCurrentUser))
            {
                return true;
            }
            else if ((B1.symbol == B2.symbol) && (B2.symbol == B3.symbol) && (B3.symbol == symbolCurrentUser))
            {
                return true;
            }
            else if ((C1.symbol == C2.symbol) && (C2.symbol == C3.symbol) && (C3.symbol == symbolCurrentUser))
            {
                return true;
            }
            else if ((A1.symbol == B1.symbol) && (B1.symbol == C1.symbol) && (C1.symbol == symbolCurrentUser))
            {
                return true;
            }
            else if ((A2.symbol == B2.symbol) && (B2.symbol == C2.symbol) && (C2.symbol == symbolCurrentUser))
            {
                return true;
            }
            else if ((A3.symbol == B3.symbol) && (B3.symbol == C3.symbol) && (C3.symbol == symbolCurrentUser))
            {
                return true;
            }

            else if ((A1.symbol == B2.symbol) && (B2.symbol == C3.symbol) && (C3.symbol == symbolCurrentUser))
            {
                return true;
            }
            else if ((A3.symbol == B2.symbol) && (B2.symbol == C1.symbol) && (C1.symbol == symbolCurrentUser))
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public FieldServer A1 = new FieldServer { field = Field.A1 };
        public FieldServer A2 = new FieldServer { field = Field.A2 };
        public FieldServer A3 = new FieldServer { field = Field.A3 };

        public FieldServer B1 = new FieldServer { field = Field.B1 };
        public FieldServer B2 = new FieldServer { field = Field.B2 };
        public FieldServer B3 = new FieldServer { field = Field.B3 };

        public FieldServer C1 = new FieldServer { field = Field.C1 };
        public FieldServer C2 = new FieldServer { field = Field.C2 };
        public FieldServer C3 = new FieldServer { field = Field.C3 };

    }
    class FieldServer
    {
        public char symbol;
        public Field field;


    }

    [DataContract]
    public enum Field
    {
        [EnumMember]
        A1,
        [EnumMember]
        A2,
        [EnumMember]
        A3,
        [EnumMember]
        B1,
        [EnumMember]
        B2,
        [EnumMember]
        B3,
        [EnumMember]
        C1,
        [EnumMember]
        C2,
        [EnumMember]
        C3
    }
}
