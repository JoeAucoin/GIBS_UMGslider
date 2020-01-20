/*
' Copyright (c) 2018  GIBS.com
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;
using System.Collections;
using System.Web.UI.WebControls;
using GIBS.Modules.GIBS_UMGslider.Components;

namespace GIBS.Modules.GIBS_UMGslider
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The Settings class manages Module Settings
    /// 
    /// Typically your settings control would be used to manage settings for your module.
    /// There are two types of settings, ModuleSettings, and TabModuleSettings.
    /// 
    /// ModuleSettings apply to all "copies" of a module on a site, no matter which page the module is on. 
    /// 
    /// TabModuleSettings apply only to the current module on the current page, if you copy that module to
    /// another page the settings are not transferred.
    /// 
    /// If you happen to save both TabModuleSettings and ModuleSettings, TabModuleSettings overrides ModuleSettings.
    /// 
    /// Below we have some examples of how to access these settings but you will need to uncomment to use.
    /// 
    /// Because the control inherits from GIBS_UMGsliderSettingsBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class Settings : GIBS_UMGsliderModuleSettingsBase
    {
        #region Base Method Implementations

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// LoadSettings loads the settings from the Database and displays them
        /// </summary>
        /// -----------------------------------------------------------------------------
        public override void LoadSettings()
        {
            try
            {
                if (Page.IsPostBack == false)
                {
                    FillDropdown();
                    //Check for existing settings and use those on this page
                    //Settings["SettingName"]

                     //uncomment to load saved settings in the text boxes
                    if(Settings.Contains("UMGModuleID"))
                        cboModuleTabId.SelectedValue = Settings["UMGModuleID"].ToString();
			
                    if (Settings.Contains("UMGTabID"))
                        cboTabId.SelectedValue = Settings["UMGTabID"].ToString();

                    if (Settings.Contains("MaxResults"))
                        cboMaxResults.SelectedValue = Settings["MaxResults"].ToString();

                    if (Settings.Contains("ContentType"))
                        cboContentType.SelectedValue = Settings["ContentType"].ToString();
                    else
                        // SHOWING FULL IMAGE
                        cboContentType.SelectedValue = "";
                    
                    if (Settings.Contains("AlbumID"))
                        ddlAlbum.SelectedValue = Settings["AlbumID"].ToString();
                    else
                        // SHOWING FULL IMAGE
                        ddlAlbum.SelectedValue = "0";

                    //DataItems
                    if (Settings.Contains("DataItems"))
                        cboDataItems.SelectedValue = Settings["DataItems"].ToString();


                }
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        public void FillDropdown()
        {

            try
            {

                DotNetNuke.Entities.Modules.ModuleController mc = new ModuleController();
                ArrayList existMods = mc.GetModulesByDefinition(this.PortalId, "BizModules - UltraPhotoGallery");
                int i = 0;

                foreach (DotNetNuke.Entities.Modules.ModuleInfo mi in existMods)
                {
                    if (!mi.IsDeleted)
                    {
                        // get module title 
                        
                        //mi.ModuleTitle;
                        // additionally, you can find out what tab it is on //mi.TabID;
                        //mi.ModuleID;
                        cboModuleTabId.Items.Insert(i, new ListItem(mi.ModuleTitle.ToString(), mi.ModuleID.ToString()));
                    }
                }


                ArrayList existTabs = mc.GetModulesByDefinition(this.PortalId, "BizModules - UltraPhotoGallery");
                int ii = 0;

                foreach (DotNetNuke.Entities.Modules.ModuleInfo mi in existMods)
                {
                    if (!mi.IsDeleted)
                    {
                        // get module title 

                        //mi.ModuleTitle;
                        // additionally, you can find out what tab it is on //mi.TabID;
                        //mi.ModuleID;
                        cboTabId.Items.Insert(ii, new ListItem(mi.ModuleTitle.ToString(), mi.TabID.ToString()));
                    }
                }


                ddlAlbum.DataSource = SliderController.GetAlbums(this.PortalId);
                ddlAlbum.DataTextField = "Title";
                ddlAlbum.DataValueField = "ItemID";
                ddlAlbum.DataBind();
                ddlAlbum.Items.Insert(0, new ListItem("-- Please Select --", "0"));

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }


        /// -----------------------------------------------------------------------------
        /// <summary>
        /// UpdateSettings saves the modified settings to the Database
        /// </summary>
        /// -----------------------------------------------------------------------------
        public override void UpdateSettings()
        {
            try
            {
                var modules = new ModuleController();
                
                //the following are two sample Module Settings, using the text boxes that are commented out in the ASCX file.
                //module settings
                modules.UpdateModuleSetting(ModuleId, "UMGTabID", cboTabId.SelectedValue.ToString());
                modules.UpdateModuleSetting(ModuleId, "UMGModuleID", cboModuleTabId.SelectedValue.ToString());
                modules.UpdateModuleSetting(ModuleId, "MaxResults", cboMaxResults.SelectedValue.ToString());
                modules.UpdateModuleSetting(ModuleId, "ContentType", cboContentType.SelectedValue.ToString());
                modules.UpdateModuleSetting(ModuleId, "AlbumID", ddlAlbum.SelectedValue.ToString());
                modules.UpdateModuleSetting(ModuleId, "DataItems", cboDataItems.SelectedValue.ToString());




                //tab module settings
                //modules.UpdateTabModuleSetting(TabModuleId, "Setting1",  txtSetting1.Text);
                //modules.UpdateTabModuleSetting(TabModuleId, "Setting2",  txtSetting2.Text);
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        #endregion
    }
}