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
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["isAdminLogin"] != null)
                    bindDataToGridView();
                else
                    Response.Redirect("AdminLogin.aspx");
            }
        }

        private void bindDataToGridView()
        {
            string filePath = Server.MapPath("~/Data/Config.json");
            //metaDataModels = JsonConvert.DeserializeObject<List<MetaDataModel>>(System.IO.File.ReadAllText(filePath));

            UserDataAccess dataAccess = new UserDataAccess();
            List<UserModel> userDataModels = dataAccess.GetUsers("SELECT * FROM User_Table;");
            gvUsers.DataSource = userDataModels;
            gvUsers.DataBind();
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

        protected void btnSave_Click(object sender, EventArgs e)
        {

            UserDataAccess dataAccess = new UserDataAccess();
            string query = "";
            if (btnSave.Text == "Save")
            {
                query = "INSERT INTO User_Table(user_name, password, is_admin) VALUES('" + txtUserName.Text + "', '" + encodePassword(txtPassword.Text) + 
                    "', " + Convert.ToInt32(chkIsAdmin.Checked) + ")";
            }
            else
            {
                /*query = "UPDATE MetaData_Table SET channelName='" + txtChannelName.Text + "', dashSrc = '" + txtDashUrl.Text + "', hlsSrc='" + txtHlsURL.Text + "', logoSrc='" +
                    txtLogoURL.Text + "', is_active = " + Convert.ToInt32(chkIsActive.Checked) + " WHERE id=" + int.Parse(hidID.Value);*/
            }
            dataAccess.Insert_Update_Delete_User(query);
            clearTextBoxes();
            bindDataToGridView();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearTextBoxes();
        }

        private void clearTextBoxes()
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtRetypePassword.Text = "";
            chkIsAdmin.Checked = false;
            hidID.Value = "";
        }

        protected void deleteUser(Object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(e.CommandArgument.ToString());
            hidID.Value = id.ToString();
            UserDataAccess dataAccess = new UserDataAccess();
            string query = "DELETE FROM User_Table WHERE id=" + id;
            dataAccess.Insert_Update_Delete_User(query);

            bindDataToGridView();

        }
    }
}