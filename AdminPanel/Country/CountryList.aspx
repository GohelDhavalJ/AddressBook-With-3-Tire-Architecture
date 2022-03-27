﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AdminPanel.master" AutoEventWireup="true" CodeFile="CountryList.aspx.cs" Inherits="AdminPanel_Country_CountryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    <div class="row">
        <div class="col-md-12">
            <h2 class="MainHeading">Country List</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12" id="divMessage" runat="server" visible="false">
            <asp:Label runat="server" ID="lblDisplay" EnableViewState="False" ForeColor="Green"></asp:Label>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-12">
            <div class="col-md-12">
                    <asp:HyperLink runat="server" ID="hlAddCountry" Text="Add New Country" NavigateUrl="~/AdminPanel/Country/CountryAddEdit.aspx" CssClass="btn btn-info" ></asp:HyperLink>
                </div>
            <br />
            <br />
            <br />
            <asp:GridView runat="server" ID="gvCountry"  CssClass="table table-hover table-responsive table-bordered table-hover"   AutoGenerateColumns="false" OnRowCommand="gvCountry_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnCountry" Text="Delete" CssClass="btn btn-danger btn-sm" OnClientClick="javascript:return confirm('Are you sure you want to delete record')" CommandName="DeleteRecord" CommandArgument='<%# Eval("CountryID").ToString() %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" Id="hlEdit" Text="Edit"  CssClass="btn btn-primary" NavigateUrl='<%# "~/AdminPanel/Country/CountryAddEdit.aspx?CountryID=" + Eval("CountryID").ToString() %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="CountryName" HeaderText="CountryName" />
                    <asp:BoundField DataField="CountryCode" HeaderText="Code" />
                </Columns>
            </asp:GridView>
        </div>     
    </div>
</asp:Content>

