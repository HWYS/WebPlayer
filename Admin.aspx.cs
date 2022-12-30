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
    public partial class Admin : System.Web.UI.Page
    {
        private List<MetaDataModel> metaDataModels = new List<MetaDataModel>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Session["isAdminLogin"] != null)
                {
                    bindDataToGridView();
                }
                else
                {
                    Response.Redirect("AdminLogin.aspx");
                }
            }
        }

        private void bindDataToGridView()
        {
            string filePath = Server.MapPath("~/Data/Config.json");
            //metaDataModels = JsonConvert.DeserializeObject<List<MetaDataModel>>(System.IO.File.ReadAllText(filePath));

            MetaDataDataAccess dataAccess = new MetaDataDataAccess();
            metaDataModels = dataAccess.GetMetaDataModels("SELECT * FROM MetaData_Table;");
            gvMetaData.DataSource = metaDataModels;
            gvMetaData.DataBind();
        }

        protected void deleteMetaData(Object sender, CommandEventArgs e)
        {
            int id = Int32.Parse( e.CommandArgument.ToString());
            hidID.Value = id.ToString();
            MetaDataDataAccess dataAccess = new MetaDataDataAccess();
            string query = "DELETE FROM MetaData_Table WHERE id=" + id;
            dataAccess.Insert_Update_Delete_MetaData(query);
            
            bindDataToGridView();
            
        }

        protected void editMetaData(Object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(e.CommandArgument.ToString());
            hidID.Value = id.ToString();
            string query = "SELECT * FROM MetaData_Table WHERE id= " + id;
            MetaDataDataAccess dataAccess = new MetaDataDataAccess();
            List<MetaDataModel> model = dataAccess.GetMetaDataModels(query);

            if(model.Count > 0)
            {
                txtChannelName.Text = model[0].channelName;
                txtDashUrl.Text = model[0].dashSrc;
                txtHlsURL.Text = model[0].hlsSrc;
                txtLogoURL.Text = model[0].logoSrc;
                chkIsActive.Checked = model[0].isActive;
                btnSave.Text = "Update";
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            MetaDataDataAccess dataAccess = new MetaDataDataAccess();
            string query = "";
            if(btnSave.Text == "Save")
            {
                query = "INSERT INTO MetaData_Table(channelName, dashSrc, hlsSrc, logoSrc, is_active) VALUES('" + txtChannelName.Text + "', '" + txtDashUrl.Text + "', '" +
                txtHlsURL.Text + "', '" + txtLogoURL.Text + "', "+Convert.ToInt32(chkIsActive.Checked)+")";
            }
            else
            {
                query = "UPDATE MetaData_Table SET channelName='" + txtChannelName.Text + "', dashSrc = '" + txtDashUrl.Text + "', hlsSrc='" + txtHlsURL.Text + "', logoSrc='" +
                    txtLogoURL.Text + "', is_active = "+ Convert.ToInt32(chkIsActive.Checked)+ " WHERE id=" + int.Parse(hidID.Value);
            }
            dataAccess.Insert_Update_Delete_MetaData(query);
            clearTextBoxes();
            bindDataToGridView();

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearTextBoxes();
        }

        private void clearTextBoxes()
        {
            txtChannelName.Text = "";
            txtDashUrl.Text = "";
            txtHlsURL.Text = "";
            txtLogoURL.Text = "";
            btnSave.Text = "Save";
            chkIsActive.Checked = true;
            hidID.Value = "";
        }
    }
}