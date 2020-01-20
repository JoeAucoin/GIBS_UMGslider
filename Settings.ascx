<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Settings.ascx.cs" Inherits="GIBS.Modules.GIBS_UMGslider.Settings" %>

<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>

<div class="dnnForm">
    <fieldset>
        <div class="dnnFormItem">
            <dnn:Label ID="Label1" runat="server" resourcekey="FromModule" ControlName="cboModuleTabId"></dnn:Label>
            <asp:DropDownList ID="cboModuleTabId" runat="server" CssClass="NormalTextBox">
                        </asp:DropDownList>
                        
        </div>

        <div class="dnnFormItem">
            <dnn:Label ID="lblFromTab" runat="server" resourcekey="FromTab" ControlName="cboTabId"></dnn:Label>
            <asp:DropDownList ID="cboTabId" runat="server">
                        </asp:DropDownList>
                        
        </div>		

        <div class="dnnFormItem">
            <dnn:Label ID="lblAlbum" runat="server" resourcekey="lblAlbum" ControlName="ddlAlbum"></dnn:Label>
            <asp:DropDownList ID="ddlAlbum" runat="server">
                        </asp:DropDownList>
                        
        </div>	

        <div class="dnnFormItem">
            <dnn:Label ID="Label3" runat="server" resourcekey="MaxResults" ControlName="cboMaxResults"></dnn:Label>
            <asp:DropDownList ID="cboMaxResults" runat="server" CssClass="NormalTextBox">
                                    <asp:ListItem Text="1"></asp:ListItem>
                                    <asp:ListItem Text="2"></asp:ListItem>
                                    <asp:ListItem Text="3"></asp:ListItem>
                                    <asp:ListItem Text="4"></asp:ListItem>
                                    <asp:ListItem Text="5"></asp:ListItem>
                                    <asp:ListItem Text="10"></asp:ListItem>
                                    <asp:ListItem Text="20" selected="true"></asp:ListItem>
                                    <asp:ListItem Text="30"></asp:ListItem>
                                    <asp:ListItem Text="40"></asp:ListItem>
                                    <asp:ListItem Text="50"></asp:ListItem>
                                </asp:DropDownList>
        </div>

                <div class="dnnFormItem">
            <dnn:Label ID="lblDataItems" runat="server" resourcekey="lblDataItems" ControlName="cboDataItems"></dnn:Label>
            <asp:DropDownList ID="cboDataItems" runat="server">
                                    <asp:ListItem Text="1"></asp:ListItem>
                                    <asp:ListItem Text="2"></asp:ListItem>
                                    <asp:ListItem Text="3"></asp:ListItem>
                                    <asp:ListItem Text="4"></asp:ListItem>
                                    <asp:ListItem Text="5"></asp:ListItem>
                                    <asp:ListItem Text="6" selected="true"></asp:ListItem>
                                    <asp:ListItem Text="7"></asp:ListItem>
                                    <asp:ListItem Text="8"></asp:ListItem>
                                    <asp:ListItem Text="9"></asp:ListItem>
                                    <asp:ListItem Text="10"></asp:ListItem>
                                </asp:DropDownList>
        </div>	


        <div class="dnnFormItem">
            <dnn:Label ID="Label2" runat="server" resourcekey="ContentType" ControlName="cboContentType"></dnn:Label>
            <asp:DropDownList ID="cboContentType" runat="server" CssClass="NormalTextBox">
                                <asp:ListItem Value="thumbs/" Text="Thumbnails"></asp:ListItem>
                                <asp:ListItem Value="" Text="Full Image"></asp:ListItem>
                            </asp:DropDownList>
        </div>
        <div class="dnnFormItem" id="divDisplayTemplates" runat="server">
            <dnn:Label ID="Label4" runat="server" resourcekey="DisplayTemplate" ControlName="cboDisplayTemplate"></dnn:Label>
            <asp:DropDownList ID="cboDisplayTemplate" runat="server" CssClass="NormalTextBox">
                            </asp:DropDownList>
        </div>
    </fieldset>
</div>

