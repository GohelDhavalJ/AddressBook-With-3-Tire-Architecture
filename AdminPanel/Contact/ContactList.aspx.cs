using AddressBook.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Contact_ContactList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillContactGridView();
        }
    }
    #endregion Load Event
    #region FillGridView
    public void FillContactGridView()
    {
        ContactBAL balContact = new ContactBAL();
        DataTable dtContact = new DataTable();

        dtContact = balContact.SelectAll();

        if (dtContact != null && dtContact.Rows.Count > 0)
        {
            gvContact.DataSource = dtContact;
            gvContact.DataBind();
        }
    }
    #endregion FillGridView

    #region gvRowCommand
    protected void gvContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                ContactBAL balContact = new ContactBAL();
                if (balContact.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    FillContactGridView();
                }
                else
                {
                    lblDisplay.Text = balContact.Message;
                    divMessage.Visible = true;
                }
            }
        }
    }
    #endregion gvRowCommand
}