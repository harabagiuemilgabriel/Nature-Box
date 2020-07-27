using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DataLibrary.Models;

namespace DataLibrary.DataAccess
{
     public static class SQLDataAccess
    {
        public static string GetConnectionString( string connectionName)
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public static int SaveData<T>(string sql, T data,string connectionName)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString(connectionName)))
            {
                return cnn.Execute(sql, data);
            }
        }

        public static void Update(string sql, string connectionName)
        {
            using(IDbConnection cnn = new SqlConnection(GetConnectionString(connectionName)))
            {
                cnn.Execute(sql);
            }
        }


        public static bool CheckUser(string sql, string connectionName,string email)
        {
            using(SqlConnection cnn=new SqlConnection(GetConnectionString(connectionName)))
            {
                DataTable dt = new DataTable();
                //cnn.Open();
                SqlCommand cmd = new SqlCommand(sql, cnn);
                //cmd.Parameters.AddWithValue("@Email", email);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                if (dt.Rows.Count > 0)
                    return true;
                else return false;
                
            }
        }
        public static bool ValidateLogin(string sql, string connectionName, string email, string password)
        {
            using (SqlConnection cnn = new SqlConnection(GetConnectionString(connectionName)))
            {
                DataTable dt = new DataTable();
                //cnn.Open();
                SqlCommand cmd = new SqlCommand(sql, cnn);
                //cmd.Parameters.AddWithValue("@Email", email);
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                if (dt.Rows.Count > 0)
                    return true;
                else return false;

            }
        }

            public static List<T> LoadData<T>(string sql, string connectionName)
        {
            using(IDbConnection cnn =new SqlConnection(GetConnectionString(connectionName)))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }

        public static List<UserModel> LoadUser(string sql, string connectionName)
        {
            using(IDbConnection cnn=new SqlConnection(GetConnectionString(connectionName)))
            {
                return cnn.Query<UserModel>(sql).ToList();
            }
        }
    }
}
