using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Player.DataAccess;
using Player.Models;

namespace Player
{
    public partial class Player : System.Web.UI.Page
    {
        public List<MetaDataModel> metaDataModels = new List<MetaDataModel>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(IsNeedToLogin())
                {
                    if (Session["isLogin"] != null || Session["isAdminLogin"] != null)
                        getMetaData();
                    else
                        Response.Redirect("Login.aspx");
                }

                else
                {
                    getMetaData();
                }
                
            }
        }

        private bool IsNeedToLogin()
        {
            SettingDataAccess dataAccess = new SettingDataAccess();
            List<SettingModel> model = dataAccess.GetSettings("SELECT * FROM Setting_Table;");
            if (model.Count > 0)
            {
                return model[0].enableUserLogin;
            }
            return true;
        }

        private void getMetaData()
        {
            string filePath = Server.MapPath("~/Data/Config.json");
            //metaDataModels = JsonConvert.DeserializeObject<List<MetaDataModel>>(System.IO.File.ReadAllText(filePath));

            MetaDataDataAccess dataAccess = new MetaDataDataAccess();
            metaDataModels = dataAccess.GetMetaDataModels("SELECT * FROM MetaData_Table WHERE is_active = 1;");
            hidMetaData.Value = JsonConvert.SerializeObject(metaDataModels, Formatting.Indented).ToString();
            bindDropDownList();
            

        }

        private void bindDropDownList()
        {
            channelDropDown.DataSource = metaDataModels;
            //channelDropDown.DataValueField = "id";
            channelDropDown.DataTextField = "channelName";
            channelDropDown.DataBind();
            if(channelDropDown.Items.Count > 0)
             channelDropDown.SelectedIndex = 0;

            foreach (ListItem item in channelDropDown.Items)
            {
                item.Attributes.Add("class", "dropdown_item");
            }
            //ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:playVideo("+metaDataModels[0]+"); ", true);
            //channelLogo.Src = metaDataModels[0].logoSrc;
            
        }

        protected void channelDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(channelDropDown.Items.Count > 0 && channelDropDown.SelectedIndex > -1)
            {
                channelLogo.Src = (Session["Metadata"] as List<MetaDataModel>)[channelDropDown.SelectedIndex].logoSrc;
            }

        }
    }
}