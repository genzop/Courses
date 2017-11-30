<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="WebSample.SiteAdministration.ProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <strong>Viewing Product Details:</strong>
    <br />
    <asp:FormView ID="frmProductDetails" runat="server" RenderOuterTable="true"
        ItemType="WebSample.BLL.Model.Product" DataKeyNames="ProductID"
        DefaultMode="ReadOnly" SelectMethod="GetProduct" 
        InsertMethod="InsertProduct" DeleteMethod="DeleteProduct"
        UpdateMethod="UpdateProduct" Width="800px" 
        OnItemCommand="frmProductDetails_ItemCommand" 
        OnItemDeleted="frmProductDetails_ItemDeleted" 
        OnItemInserted="frmProductDetails_ItemInserted" >
        <ItemTemplate>
            <strong>Product Name:</strong>
            <br />
            <asp:DynamicControl runat="server" ID="dynName" DataField="Name" Mode="ReadOnly" />
            <br />
            <br />
            <strong>Product Category Name:</strong>
            <br />
            <%# Item.Category.Name %>
            <br />
            <br />
            <strong>Description:</strong>
            <br />
            <asp:DynamicControl runat="server" ID="dynDescription" DataField="Description" Mode="ReadOnly" />
            <br />
            <br />
            <strong>Price:</strong>
            <br />
            ($)  <asp:DynamicControl runat="server" ID="dynPrice" DataField="Price" Mode="ReadOnly" />
            <br />
            <br />
            <strong>Available Units in Stock:</strong>
            <br />
            <asp:DynamicControl runat="server" ID="dynUnitsInSock" DataField="UnitsInStock" Mode="ReadOnly" /> (Units) 
            <br />
            <br />
            <strong>Stock Last Update:</strong>
            <br />
            <%# Item.LastUpdated.ToLongDateString() %> : <%# Item.LastUpdated.ToLongTimeString() %>
            <br />
            <asp:LinkButton ID="lnkNewProduct" runat="server" CommandName="New">Add Product</asp:LinkButton>
            <asp:LinkButton ID="lnkEditProduct" runat="server" CommandName="Edit">Edit Product</asp:LinkButton>
            <asp:LinkButton ID="lnkDeleteProduct" runat="server" CommandName="Delete">Delete Product</asp:LinkButton>
            </ItemTemplate>
            <InsertItemTemplate>
            <strong>Product Name:</strong>
            <br />
            <asp:DynamicControl runat="server" ID="dynInsertName" DataField="Name" Mode="Insert" ValidationGroup="Insert" />
            <br />
            <br />
            <strong>Product Category Name:</strong>
            <br />
            &nbsp;<asp:DropDownList ID="cmbInsertProductCategory" runat="server"
                ItemType="WebSample.BLL.Model.ToyCategory"
                SelectedValue="<%# BindItem.CategoryID %>"
                SelectMethod="GetCategories" 
                DataTextField="Name" DataValueField="CategoryID">
            </asp:DropDownList>
            <br />
            <br />
            <strong>Description:</strong>
            <br />
            <asp:DynamicControl runat="server" ID="dynInsetDesription" DataField="Description" Mode="Insert" ValidationGroup="Insert" />
            <br />
            <br />
            <strong>Price:</strong>
            <br />
            ($) <asp:DynamicControl runat="server" ID="dynInsertPrice" DataField="Price" Mode="Insert" ValidationGroup="Insert" />
            <br />
            <br />
            <strong>Available Units in Stock:</strong>
            <br />
            <asp:DynamicControl runat="server" ID="dynInsertUnits" DataField="UnitsInStock" Mode="Insert" ValidationGroup="Insert" /> (Units) 
            <br />
            <br />
            <strong>Stock Last Update:</strong>
            <br />
            <asp:DynamicControl runat="server" ID="dynInsertStockLastUpdate" DataField="LastUpdated" Mode="Insert" ValidationGroup="Insert" />
            <br />
            <asp:ValidationSummary ID="vsInsertSummary" runat="server" ValidationGroup="Insert" CssClass="field-validation-error"/>
            <br />
            <asp:LinkButton ID="lnkInsert" runat="server" CommandName="Insert" ValidationGroup="Insert">Create Product</asp:LinkButton>
            <asp:LinkButton ID="lnkCancelInsert" runat="server" CommandName="Cancel" CausesValidation="false">Cancel</asp:LinkButton>
        </InsertItemTemplate>
        <EditItemTemplate>
            <strong>Product Name:</strong>
            <br />
            <asp:DynamicControl runat="server" ID="dynEditName" DataField="Name" Mode="Edit" ValidationGroup="Edit" />
            <br />
            <br />
            <strong>Product Category Name:</strong>
            <br />
            &nbsp;<asp:DropDownList ID="cmbEditCategories" runat="server"
                ItemType ="WebSample.BLL.Model.ToyCategory" 
                SelectedValue='<%# BindItem.CategoryID %>' 
                SelectMethod="GetCategories" 
                DataTextField="Name" DataValueField="CategoryID">
		    </asp:DropDownList>
            <br />
            <br />
            <strong>Description:</strong>
            <br />
            <asp:DynamicControl runat="server" ID="dynEditDescription" DataField="Description" Mode="Edit" ValidationGroup="Edit" />
            <br />
            <br />
            <strong>Price:</strong>
            <br />
            ($) <asp:DynamicControl runat="server" ID="dynEditPrice" DataField="Price" Mode="Edit" ValidationGroup="Edit" />
            <br />
            <br />
            <strong>Available Units in Stock:</strong>
            <br />
            <asp:DynamicControl runat="server" ID="dynEditUnits" DataField="UnitsInStock" Mode="Edit" ValidationGroup="Edit" /> (Units) 
            <br />
            <br />
            <strong>Stock Last Update:</strong>
            <br />
            <asp:DynamicControl runat="server" ID="dynEditStockLastUpdate" DataField="LastUpdated" Mode="Edit" ValidationGroup="Edit" />
            <br />
            <asp:ValidationSummary ID="vsEditSummary" runat="server" ValidationGroup="Edit" CssClass="field-validation-error"/>
            <br />
            <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="Update" ValidationGroup="Edit">Update Product</asp:LinkButton>
            <asp:LinkButton ID="lnkCancelUpdate" runat="server" CommandName="Cancel" CausesValidation="false">Cancel</asp:LinkButton>
        </EditItemTemplate>
    </asp:FormView>
    <br />
    <asp:ModelErrorMessage ID="merProductErrors" runat="server" CssClass="field-validation-error" ModelStateKey="NotFoundError" />
</asp:Content>
