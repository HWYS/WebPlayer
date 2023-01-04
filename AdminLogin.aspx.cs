using Newtonsoft.Json;
using Player.DataAccess;
using Player.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Player
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Session["isAdminLogin"] != null)
                {
                    Response.Redirect("Admin.aspx");
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            /*UserDataAccess dataAccess = new UserDataAccess();
            List<UserModel> model = dataAccess.GetUsers("SELECT * FROM User_Table WHERE user_name ='" + txtUserName.Text + "' AND password= '" + encodePassword(txtPassword.Text) + "'");*/
            string filePath = Server.MapPath("~/Data/Users.json");
            List<UserModel> userModels = JsonConvert.DeserializeObject<List<UserModel>>(System.IO.File.ReadAllText(filePath));
            UserModel model = userModels.Where(x => x.userName == txtUserName.Text && x.password == encodePassword(txtPassword.Text)).FirstOrDefault();

            if (model != null)
            {
                if (model.isAdmin)
                {
                    Session["isAdminLogin"] = true;
                    Response.Redirect("Admin.aspx");
                }
                    
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only Admin account are allowed to login')", true);
                }

                
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Wrong User Name of Password')", true);
            }
        }

        private string encodePassword(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
    }
}