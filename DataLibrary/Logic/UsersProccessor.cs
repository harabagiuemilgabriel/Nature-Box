using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Logic
{
    public static class UsersProccessor
    {
        public static List<UserModel> LoadUsers(string table, string DBName)
        {
            string sql = @"select Id, UserFirstName, UserLastName, UserEmail, UserConfirmEmail,UserToken,UserPassword
                         from " + table + ";";

            return SQLDataAccess.LoadUser(sql, DBName);
        }

        public static int CreateUser(string DBName,
                                        string table,
                                        string firstName,
                                        string lastName,
                                        string email,
                                        int confirmEmail,
                                        string token,
                                        string password)
        {
            UserModel data = new UserModel
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                ConfirmEmail=confirmEmail,
                Token = token,
                Password=password
            };

            string sql = @"insert into dbo." + table + "(UserFirstName, UserLastName, UserEmail, UserConfirmEmail, UserToken, UserPassword) values (@FirstName, @LastName, @Email, @ConfirmEmail, @Token, @Password);";

            return SQLDataAccess.SaveData(sql, data, DBName);
        }

        public static bool Validate(string DBName, string table, string email)
        {
            string sql = "SELECT * FROM " + table + " WHERE UserEmail ='"+email+"'";

            return SQLDataAccess.CheckUser(sql, DBName,email);
        }

        public static bool Login(string DBName, string table, string email, string password)
        {
            string sql = "SELECT * FROM " + table + " WHERE UserEmail = '" + email + "' AND UserPassword = '" + password + "'";
            return SQLDataAccess.ValidateLogin(sql, DBName, email, password);
        }

    }
}
