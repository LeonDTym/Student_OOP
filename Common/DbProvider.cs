using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Data.SQLite;

using WindowsFormsApp1.Models;
using System.Windows.Forms;
using WindowsFormsApp1.Forms;

namespace WindowsFormsApp1.Common {
    public class DbProvider {

        /// <summary>
        /// Словарь команд для адресов
        /// </summary>
        //static Dictionary<OperationType, string> addressCommands = 
        //    new Dictionary<OperationType, string>();


        /// <summary>
        /// Словарь команд для пользователей
        /// </summary>
        static Dictionary<OperationType, string> userCommands = 
            new Dictionary<OperationType, string>();

        /// <summary>
        /// Строка соединения
        /// </summary>
        static string CONNECT_STR = string.Format("Data Source={0}",
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database.db"));

        /// <summary>
        /// Поле синглета
        /// </summary>
        private static DbProvider _provider = null;

        /// <summary>
        /// Свойство синглета
        /// </summary>
        public static DbProvider Provider {
            get {
                if (_provider == null) {
                    _provider = new DbProvider();
                }
                return _provider;
            }
        }

        /// <summary>
        /// Статический конструктор типа
        /// </summary>
        static DbProvider() {
            //Заполнение словарей команд
            FillCommands();
        }

        /// <summary>
        /// Приватный конструктор экземпляра
        /// </summary>
        private DbProvider() { }

        /// <summary>
        /// Получение коллекции всех пользователей в БД
        /// </summary>
        /// <returns></returns>
        public StudentInfo[] GetUsers() {
            List<StudentInfo> users = new List<StudentInfo>();
            string selectUser = "SELECT * FROM Users";
            using (SQLiteConnection cnn = new SQLiteConnection(CONNECT_STR)) {
                cnn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(selectUser, cnn)) {
                    using (SQLiteDataReader dr = cmd.ExecuteReader()) {
                        while (dr.Read()) {
                            StudentInfo user = new StudentInfo {
                                UserId=int.Parse(dr["id"].ToString()),
                                FirstName=(string)dr["fName"],
                                SecondName=(string)dr["sName"],
                                LastName=(string)dr["lName"],
                                Bth=(string)dr["date"],
                                Grp=(string)dr["gro"],
                            };
                            //user.Address = GetAddressById(user.UserId);
                            users.Add(user);
                        }
                    }
                }
            }
            return users.ToArray();
        }

        /// <summary>
        /// Получение пользователя по его UserId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StudentInfo GetUserById(int id) {
            string command = string.Format("SELECT * FROM Users WHERE id='{0}'", id);
            using (SQLiteConnection cnn = new SQLiteConnection(CONNECT_STR)) {
                cnn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(command, cnn)) {
                    using (SQLiteDataReader dr = cmd.ExecuteReader()) {
                        if (!dr.HasRows) {
                            return StudentInfo.Empty;
                        }
                        dr.Read();
                        StudentInfo user = new StudentInfo {
                            UserId = int.Parse(dr["id"].ToString()),
                            FirstName = (string)dr["fName"],
                            SecondName = (string)dr["sName"],
                            LastName = (string)dr["lName"],
                            Bth = (string)dr["date"],
                            Grp = (string)dr["gro"],
                        };
                        //user.Address = GetAddressById(user.UserId);
                        return user;
                    }
                }
            }
        }

        /// <summary>
        /// Операция с пользователем (вставка/редактирование/удаление)
        /// </summary>
        ///// <param name="user">Пользователь</param>
        ///// <param name="operation">Тип операции</param>
        public void OperateUser(StudentInfo student, OperationType operation) {
            string command = string.Format(userCommands[operation], student.UserId, student.FirstName, student.SecondName, student.LastName, student.Bth, student.Grp /*user.DateBth*/) ;
            using (SQLiteConnection cnn = new SQLiteConnection(CONNECT_STR)) {
                cnn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(command, cnn)) {
                    try
                    {
                        cmd.ExecuteNonQuery();// Выполняет инструкцию Transact-SQL для соединения и возвращает количество затронутых строк.

                    }
                    catch (Exception) { }
                 
                }
            }

           // OperateAddress(user.Address, operation);
        }

        /// <summary>
        /// Получение адреса пользователя по его UserId
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Адрес пользователя</returns>
        //public AddressInfo GetAddressById(int id) {
        //    string selectAddr = string.Format("SELECT * FROM Addresses WHERE id='{0}'", id);
        //    using (SQLiteConnection cnn = new SQLiteConnection(CONNECT_STR)) {
        //        cnn.Open();
        //        using (SQLiteCommand cmd = new SQLiteCommand(selectAddr, cnn)) {
        //            using (SQLiteDataReader dr = cmd.ExecuteReader()) {
        //                if (!dr.HasRows) {
        //                    return AddressInfo.Empty;
        //                }
        //                dr.Read();
        //                return new AddressInfo {
        //                    UserId=id,
        //                    Country=(string)dr["country"],
        //                    City=(string)dr["city"],
        //                    Street=(string)dr["street"],
        //                    HouseNumber=int.Parse(dr["house"].ToString())
        //                };
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// Операция с адресом(вставка/редактирование/удаление)
        /// </summary>
        /// <param name="address">Адрес</param>
        /// <param name="operation">Тип операции</param>
        //void OperateAddress(AddressInfo address, OperationType operation) {
        //    string command = string.Format(addressCommands[operation], address.UserId,address.Country,address.City,address.Street, address.HouseNumber);
        //    using (SQLiteConnection cnn = new SQLiteConnection(CONNECT_STR)) {
        //        cnn.Open();
        //        using (SQLiteCommand cmd = new SQLiteCommand(command, cnn)) {
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //}

        /// <summary>
        /// Метод заполнения словарей команд
        /// </summary>
        static void FillCommands() {
            userCommands.Add(OperationType.INSERT, "INSERT INTO Users VALUES('{0}','{1}','{2}','{3}','{4}','{5}')");
            userCommands.Add(OperationType.UPDATE, "UPDATE Users SET fName='{1}', sName='{2}', lName='{3}', date='{4}', gro='{5}' WHERE id='{0}'");
            userCommands.Add(OperationType.DELETE, "DELETE FROM Users WHERE id='{0}'");

            //addressCommands.Add(OperationType.INSERT, "INSERT INTO Addresses VALUES('{0}','{1}','{2}','{3}','{4}')");
            //addressCommands.Add(OperationType.UPDATE, "UPDATE Addresses SET country='{1}',city='{2}',street='{3}',house='{4}' WHERE id='{0}'");
            //addressCommands.Add(OperationType.DELETE, "DELETE FROM Addresses WHERE id='{0}'");
        }
    }

    /// <summary>
    /// Перечисление типов операций
    /// </summary>
    public enum OperationType {
        INSERT,
        UPDATE,
        DELETE
    }
}
