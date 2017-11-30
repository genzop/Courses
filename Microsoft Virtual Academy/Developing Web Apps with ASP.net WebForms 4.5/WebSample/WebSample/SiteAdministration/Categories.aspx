<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="WebSample.SiteAdministration.Categories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <strong> Categories Listings: </strong>
    <br />
    <asp:GridView runat="server"  ID="ToyCategories"  PageSize="5" Width="800px" 
            ItemType="WebSample.BLL.Model.ToyCategory" DataKeyNames="CategoryID" AllowPaging="true"
            AutoGenerateColumns="False" AllowSorting="True" 
            SelectMethod="GetCategories" BorderWidth="1px">

          <Columns>
                <asp:DynamicField DataField="Name" />
                <asp:DynamicField DataField="ShortDescription"/>
                <asp:DynamicField DataField="LastUpdated" />

              <asp:TemplateField ShowHeader="False">
                	<ItemTemplate>
                        <a id="A1" runat="server" href='<%# GetRouteUrl("CategoryDetails", new {id = Item.CategoryID}) %>'>View Details</a>
                	</ItemTemplate>
            	</asp:TemplateField>
          </Columns>

          <SortedAscendingHeaderStyle CssClass="asc" />
          <SortedDescendingHeaderStyle CssClass="desc" />
    </asp:GridView>
    <br />
    <a href="<%: GetRouteUrl("NewCategory", null) %>">Add New Category</a>
    <br />
    <br />
</asp:Content>
