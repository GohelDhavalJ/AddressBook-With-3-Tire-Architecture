<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="ContactCategoryList.aspx.cs" Inherits="AdminPanel_ContactCategory_ContactCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2 class="MainHeading">Contact Category List</h2>
        </div>

        <div class="row">
            <div class="col-md-12" id="divMessage" runat="server" visible="false">
                <asp:Label runat="server" ID="lblDisplay" EnableViewState="False" ForeColor="Green"></asp:Label>
            </div>
        </div>
        <br />
    </div>
    <div class="row">
        <div class="col-md-12">
             <div class="col-md-12">
                    <asp:HyperLink runat="server" ID="hlAddContactCategory" Text="Add New Contact Category" NavigateUrl="~/AdminPanel/ContactCategory/ContactCategoryAddEdit.aspx" CssClass="btn btn-info"></asp:HyperLink>
                </div>
            <br />
            <br />
            <br />
            <asp:GridView ID="gvContactCategory" runat="server" CssClass="table table-hover table-responsive table-bordered table-hover"  AutoGenerateColumns="false" OnRowCommand="gvContactCategory_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" Text="Delete" OnClientClick="javascript:return confirm('Are you sure you want to delete record')" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument='<%# Eval("ContactCategoryID").ToString() %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="btnEdit" Text="Edit" CssClass="btn btn-primary" NavigateUrl='<%# "~/AdminPanel/ContactCategory/ContactCategoryAddEdit.aspx?ContactCategoryID=" + Eval("ContactCategoryID").ToString() %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="ContactCategoryName" HeaderText="Name" />
                </Columns>
            </asp:GridView>
        </div>      
    </div>
</asp:Content>

