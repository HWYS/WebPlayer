using Newtonsoft.Json;
using Player.DataAccess;
using Player.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            string filePath = Server.MapPath("~/Data/MetaData.json");
            metaDataModels = JsonConvert.DeserializeObject<List<MetaDataModel>>(System.IO.File.ReadAllText(filePath));

            /*MetaDataDataAccess dataAccess = new MetaDataDataAccess();
            metaDataModels = dataAccess.GetMetaDataModels("SELECT * FROM MetaData_Table;");*/
            gvMetaData.DataSource = metaDataModels;
            gvMetaData.DataBind();
        }

        protected void deleteMetaData(Object sender, CommandEventArgs e)
        {
            int id = Int32.Parse( e.CommandArgument.ToString());
            hidID.Value = id.ToString();
            /*MetaDataDataAccess dataAccess = new MetaDataDataAccess();
            string query = "DELETE FROM MetaData_Table WHERE id=" + id;
            dataAccess.Insert_Update_Delete_MetaData(query);*/

            string filePath = Server.MapPath("~/Data/MetaData.json");
            metaDataModels = JsonConvert.DeserializeObject<List<MetaDataModel>>(System.IO.File.ReadAllText(filePath));
            MetaDataModel model = metaDataModels.Where(x => x.id == id).FirstOrDefault();
            metaDataModels.Remove(model);

            string output = Newtonsoft.Json.JsonConvert.SerializeObject(metaDataModels, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, output);
            bindDataToGridView();
            
        }

        protected void editMetaData(Object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(e.CommandArgument.ToString());
            hidID.Value = id.ToString();
            /*string query = "SELECT * FROM MetaData_Table WHERE id= " + id;
            MetaDataDataAccess dataAccess = new MetaDataDataAccess();
            List<MetaDataModel> model = dataAccess.GetMetaDataModels(query);*/
            string filePath = Server.MapPath("~/Data/MetaData.json");
            metaDataModels = JsonConvert.DeserializeObject<List<MetaDataModel>>(System.IO.File.ReadAllText(filePath));
            

            if (metaDataModels.Count > 0)
            {
                MetaDataModel model = metaDataModels.Where(x => x.id == id).FirstOrDefault();
                txtChannelName.Text = model.channelName;
                txtDashUrl.Text = model.dashSrc;
                txtHlsURL.Text = model.hlsSrc;
                txtLogoURL.Text = model.logoSrc;
                chkIsActive.Checked = model.isActive;
                btnSave.Text = "Update";
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string filePath = Server.MapPath("~/Data/MetaData.json");
            metaDataModels = JsonConvert.DeserializeObject<List<MetaDataModel>>(System.IO.File.ReadAllText(filePath));

            //MetaDataDataAccess dataAccess = new MetaDataDataAccess();
            string query = "";
            if(btnSave.Text == "Save")
            {
                //query = "INSERT INTO MetaData_Table(channelName, dashSrc, hlsSrc, logoSrc, is_active) VALUES('" + txtChannelName.Text + "', '" + txtDashUrl.Text + "', '" +
                //txtHlsURL.Text + "', '" + txtLogoURL.Text + "', "+Convert.ToInt32(chkIsActive.Checked)+")";
                MetaDataModel model = new MetaDataModel();
                model.id = gvMetaData.Rows.Count + 1;
                model.channelName = txtChannelName.Text;
                model.dashSrc = txtDashUrl.Text;
                model.hlsSrc = txtHlsURL.Text;
                model.logoSrc = txtLogoURL.Text;
                model.isActive = chkIsActive.Checked;
                metaDataModels.Add(model);
            }
            else
            {
                //query = "UPDATE MetaData_Table SET channelName='" + txtChannelName.Text + "', dashSrc = '" + txtDashUrl.Text + "', hlsSrc='" + txtHlsURL.Text + "', logoSrc='" +
                //    txtLogoURL.Text + "', is_active = "+ Convert.ToInt32(chkIsActive.Checked)+ " WHERE id=" + int.Parse(hidID.Value);
                MetaDataModel model = metaDataModels.Where(x => x.id == Convert.ToInt32(hidID.Value)).FirstOrDefault();
                model.channelName = txtChannelName.Text;
                model.dashSrc = txtDashUrl.Text;
                model.hlsSrc = txtHlsURL.Text;
                model.logoSrc = txtLogoURL.Text;
                model.isActive = chkIsActive.Checked;
            }
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(metaDataModels, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, output);
            //dataAccess.Insert_Update_Delete_MetaData(query);
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