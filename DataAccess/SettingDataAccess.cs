using Player.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace Player.DataAccess
{
    public class SettingDataAccess
    {
        public List<SettingModel> GetSettings(string query)
        {
            var result = new List<SettingModel>();
            if (string.IsNullOrEmpty(query.Trim()))
                return null;

            using (var con = new SQLiteConnection(@"Data Source=" + System.Web.HttpContext.Current.Server.MapPath(@"~\App_Data\PlayerDb.sqlite; Version=3; FailIfMissing=True;")))
            {
                con.Open();
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.CommandText = query;
                    cmd.CommandType = System.Data.CommandType.Text;

                    SQLiteDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        SettingModel model = new SettingModel();
                        model.id = Convert.ToInt32(reader["id"]);
                        model.enableUserLogin = Convert.ToBoolean(reader["enable_user_login"]);
                        result.Add(model);
                    }
                }
                con.Close();
            }
            return result;
        }

        public bool Insert_Update_Delete_Setting(string query)
        {
            
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
                con.Close();
            }
            return true;
        }
    }
}