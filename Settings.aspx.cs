using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Player.DataAccess;
using Player.Models;

namespace Player
{
    public partial class Settings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Session["isAdminLogin"] != null)
                {
                    GetSettings();
                }
                else
                {
                    Response.Redirect("AdminLogin.aspx");
                }
            }
        }

        private void GetSettings()
        {
            SettingDataAccess dataAccess = new SettingDataAccess();
            List<SettingModel> model = dataAccess.GetSettings("SELECT * FROM Setting_Table;");
            if(model.Count > 0)
            {
                chkIsLogin.Checked = model[0].enableUserLogin;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SettingDataAccess dataAccess = new SettingDataAccess();
            dataAccess.Insert_Update_Delete_Setting("UPDATE Setting_Table SET enable_user_login =" + Convert.ToInt32(chkIsLogin.Checked) + " WHERE id= 1;");
            GetSettings();
        }
    }
}