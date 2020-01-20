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
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;
using GIBS.Modules.GIBS_UMGslider.Components;
using DotNetNuke.Common;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Framework.JavaScriptLibraries;

namespace GIBS.Modules.GIBS_UMGslider
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The View class displays the content
    /// 
    /// Typically your view control would be used to display content or functionality in your module.
    /// 
    /// View may be the only control you have in your project depending on the complexity of your module
    /// 
    /// Because the control inherits from GIBS_UMGsliderModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    /// 

    

    public partial class View : GIBS_UMGsliderModuleBase, IActionable
    {

        public string _ModuleID = "";
        public string _TabID = "";
        public string _ContentType = "";
        public string _MaxResults = "6";
        public string _GalleryURL = "";
        public string _AlbumID = "0";
        public string _DataItems = "6";


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

       //     JavaScript.RequestRegistration(CommonJs.jQuery);
       //     JavaScript.RequestRegistration(CommonJs.jQueryUI);
            Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "SlickJS", ("https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.9.0/slick.min.js"));
        //    Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "Slick", (this.TemplateSourceDirectory + "/Javascript/Myscript.js"));
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                

                if (!IsPostBack)
                {
                    //this.PortalSettings.HomeDirectory.ToString();
                }

                if (Settings.Contains("UMGModuleID"))
                {
              //      LblDebug.Text = "ModuleID: " + Settings["UMGModuleID"].ToString() + "<br />";
                    _ModuleID = Settings["UMGModuleID"].ToString();
                }
                if (Settings.Contains("UMGTabID"))
                {
             //       LblDebug.Text += "TabID: " + Settings["UMGTabID"].ToString() + "<br />";
                    _TabID = Settings["UMGTabID"].ToString();
                    var galleryUrl = Globals.NavigateURL(Int32.Parse(_TabID), this.Request.QueryString["ctl"], UrlUtils.GetQSParamsForNavigateURL());
                    _GalleryURL = galleryUrl.ToString();
                }

                
                if (Settings.Contains("ContentType"))
                {
              //      LblDebug.Text += "ContentType: " + Settings["ContentType"].ToString() + "<br />";
                    _ContentType = Settings["ContentType"].ToString();
                }

                if (Settings.Contains("MaxResults"))
                {
              //      LblDebug.Text += "MaxResults: " + Settings["MaxResults"].ToString() + "<br />";
                    _MaxResults = Settings["MaxResults"].ToString();
                }
                //_AlbumID
                if (Settings.Contains("AlbumID"))
                {
                    _AlbumID = Settings["AlbumID"].ToString();
                }
                //_DataItems
                if (Settings.Contains("DataItems"))
                {
                    _DataItems = Settings["DataItems"].ToString();
                }


                //  LblDebug.Text = galleryUrl.ToString();
                if (_ModuleID.ToString().Length > 0)
                {
                    FillRepeater();
                }
                


            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }


        public void FillRepeater()
        {

            try
            {

                rptMedia.DataSource = SliderController.GetItems(Int32.Parse(_AlbumID), Int32.Parse(_MaxResults.ToString()), Int32.Parse(_ModuleID.ToString()));
                rptMedia.DataBind();

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }

        }


        public ModuleActionCollection ModuleActions
        {
            get
            {
                var actions = new ModuleActionCollection
                    {
                        {
                            GetNextActionID(), Localization.GetString("EditModule", LocalResourceFile), "", "", "",
                            EditUrl(), false, SecurityAccessLevel.Edit, true, false
                        }
                    };
                return actions;
            }
        }
    }
}