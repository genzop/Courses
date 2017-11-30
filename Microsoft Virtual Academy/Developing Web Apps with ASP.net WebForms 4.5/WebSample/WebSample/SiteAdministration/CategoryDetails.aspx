<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoryDetails.aspx.cs" Inherits="WebSample.SiteAdministration.CategoryDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <strong>Category Details:</strong>
    <br />
    <asp:FormView ID="frmCategoryDetails" runat="server" RenderOuterTable="true" ItemType="WebSample.BLL.Model.ToyCategory"
            DataKeyNames="CategoryID" DefaultMode="ReadOnly" 
            SelectMethod="GetCategory" Width="800px"  InsertMethod="InsertToyCategory" UpdateMethod="UpdateToyCategory" 
            DeleteMethod="DeleteToyCategory"
            OnItemCommand="frmCategoryDetails_ItemCommand" 
            OnItemDeleted="frmCategoryDetails_ItemDeleted" 
            OnItemInserted="frmCategoryDetails_ItemInserted">
            <ItemTemplate>
                <strong>Category Name:</strong>
                <br />
                <asp:DynamicControl runat="server" ID="dynName" DataField="Name" Mode="ReadOnly" />
                <br />
                <br />
                <strong>Short Description</strong>
                <br />
                <asp:DynamicControl runat="server" ID="dynShortDescription" DataField="ShortDescription" Mode="ReadOnly" />
                <br />
                <br />
                <strong>Description:</strong>
                <br />
                <asp:DynamicControl runat="server" ID="dynDescription" DataField="Description" Mode="ReadOnly" />
                <br />
                <br />
                <strong>Last Updated</strong>
                <br />
                <%# Item.LastUpdated.ToLongDateString() %> : <%# Item.LastUpdated.ToLongTimeString() %>
                <br />
                <br />
                <asp:LinkButton ID="lnkNewCategory" runat="server" CommandName="New">Add Category</asp:LinkButton>
                <asp:LinkButton ID="lnkEditCategory" runat="server" CommandName="Edit">Edit Category</asp:LinkButton>
                <asp:LinkButton ID="lnkDeleteCategory" runat="server" CommandName="Delete">Delete Category</asp:LinkButton>
            </ItemTemplate>
            <InsertItemTemplate>
                <strong>Category Name:</strong>
                <br />
                <asp:DynamicControl runat="server" ID="dynInsertName" DataField="Name" Mode="Insert" ValidationGroup="Insert"/>
                <br />
                <br />
                <strong>Description:</strong>
                <br />
                <asp:DynamicControl runat="server" ID="dynInsertDescription" DataField="Description" Mode="Insert" ValidationGroup="Insert"/>
                <br />
                <br />
                <asp:ValidationSummary ID="vsInsertSummary" runat="server" ValidationGroup="Insert" CssClass="field-validation-error"/>
                <br />
                <asp:LinkButton ID="lnkInsert" runat="server" CommandName="Insert" ValidationGroup="Insert">Create Category</asp:LinkButton>
                <asp:LinkButton ID="lnkCancelInsert" runat="server" CommandName="Cancel" CausesValidation="false">Cancel</asp:LinkButton>
            </InsertItemTemplate>
            <EditItemTemplate>
                <strong>Category Name:</strong>
                <br />
                <asp:DynamicControl runat="server" ID="dynEditName" DataField="Name" Mode="Edit" ValidationGroup="Edit" />
                <br />
                <br />
                <strong>Description:</strong>
                <br />
                <asp:DynamicControl runat="server" ID="dynEditDescription" DataField="Description" Mode="Edit" ValidationGroup="Edit" />
                <br />
                <br />
                <strong>Last Updated</strong>
                <br />
                <%# Item.LastUpdated.ToLongDateString() %> : <%# Item.LastUpdated.ToLongTimeString() %>
                <br />
                <br />
                <asp:ValidationSummary ID="vsEditSummary" runat="server" ValidationGroup="Edit" CssClass="field-validation-error"/>
                <br />
                <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="Update" ValidationGroup="Edit">Update Category</asp:LinkButton>
                <asp:LinkButton ID="lnkCancelUpdate" runat="server" CommandName="Cancel" CausesValidation="false">Cancel</asp:LinkButton>
            </EditItemTemplate>
        </asp:FormView>
        <br />
        <asp:ModelErrorMessage ID="merCategoryErrors" runat="server" CssClass="field-validation-error" ModelStateKey="NotFoundError" />
</asp:Content>
