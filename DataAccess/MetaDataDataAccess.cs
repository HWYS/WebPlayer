using Player.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace Player.DataAccess
{
    public class MetaDataDataAccess
    {
        private static string connectionString = @"Data Source=PATH_TO_DB_FILE\...\file.ABC; Version=3; FailIfMissing=True; Foreign Keys=True;";

        public List<MetaDataModel> GetMetaDataModels(string query)
        {
            var result = new List<MetaDataModel>();
            if (string.IsNullOrEmpty(query.Trim()))
                return null;

            using (var con = new SQLiteConnection(@"Data Source="+ System.Web.HttpContext.Current.Server.MapPath(@"~\App_Data\PlayerDb.sqlite")))
            {
                con.Open();
                using(var cmd = new SQLiteCommand(query, con))
                {
                    cmd.CommandText = query;
                    cmd.CommandType = System.Data.CommandType.Text;

                    SQLiteDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        MetaDataModel model = new MetaDataModel();
                        model.dashSrc = Convert.ToString(reader["dashSrc"]);
                        model.hlsSrc = Convert.ToString(reader["hlsSrc"]);
                        model.logoSrc = Convert.ToString(reader["logoSrc"]);
                        model.channelName = Convert.ToString(reader["channelName"]);
                        model.id = Convert.ToInt32(reader["id"]);
                        model.isActive = Convert.ToBoolean(reader["is_active"]);
                        result.Add(model);
                    }
                }
                con.Close();
            }
            return result;
        }

        public bool Insert_Update_Delete_MetaData(string query)
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
                    } catch(Exception e)
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





