<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductsRep.aspx.cs" Inherits="WebSample.SiteAdministration.ProductsRep" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <strong>Product Listings: (via repository)</strong>
    <br />
    <asp:GridView ID="ProductsList" runat="server" ItemType="WebSample.BLL.Model.Product"  GridLines="Horizontal"
        SelectMethod="GetProducts" AutoGenerateColumns="False" AllowSorting="true" AllowPaging="true" DataKeyNames="ProductID"
        PageSize="5" Width="800px" BorderWidth="1px">
             <Columns>
                <asp:DynamicField DataField="Name" />
                <asp:DynamicField DataField="ShortDescription"/>
                <asp:DynamicField DataField="Price"/>
                <asp:DynamicField DataField="UnitsInStock"/>
                <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <a id="A1" runat="server" href='<%# GetRouteUrl("ProductDetails", new {id = Item.ProductID}) %>'>View Details</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

        <SortedAscendingHeaderStyle CssClass="asc" />
        <SortedDescendingHeaderStyle CssClass="desc" />
    </asp:GridView>
    <br />
    <a href="<%: GetRouteUrl("NewProduct", null) %>">Add New Product</a>
    <br />
    <br />
</asp:Content>
