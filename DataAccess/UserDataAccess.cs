using Player.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace Player.DataAccess
{
    public class UserDataAccess
    {
        public List<UserModel> GetUsers(string query)
        {
            var result = new List<UserModel>();
            if (string.IsNullOrEmpty(query.Trim()))
                return null;

            using (var con = new SQLiteConnection(@"Data Source=" + System.Web.HttpContext.Current.Server.MapPath(@"~\App_Data\PlayerDb.sqlite")))
            {
                con.Open();
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.CommandText = query;
                    cmd.CommandType = System.Data.CommandType.Text;

                    SQLiteDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        UserModel model = new UserModel();
                        model.userName = Convert.ToString(reader["user_name"]);
                        model.password = Convert.ToString(reader["password"]);
                        model.id = Convert.ToInt32(reader["id"]);
                        model.isAdmin = Convert.ToBoolean(reader["is_admin"]);
                        result.Add(model);
                    }
                }
            }
            return result;
        }

        public bool Insert_Update_Delete_User(string query)
        {
            var result = new List<MetaDataModel>();
            if (string.IsNullOrEmpty(query.Trim()))
                return false;

            using (var con = new SQLiteConnection(@"Data Source=" + System.Web.HttpContext.Current.Server.MapPath(@"~\App_Data\PlayerDb.sqlite")))
            {
                con.Open();
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.CommandText = query;
                    cmd.CommandType = System.Data.CommandType.Text;

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}