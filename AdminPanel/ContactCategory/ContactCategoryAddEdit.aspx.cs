using AddressBook;
using AddressBook.BAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_ContactCategory_ContactCategoryAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["ContactCategoryID"] != null)
            {
                FillControls(Convert.ToInt32(Request.QueryString["ContactCategoryID"]));
            }
        }
    }
    #endregion Load Event

    #region FillControls
    private void FillControls(SqlInt32 ContactCategoryID)
    {
        ContactCategoryENT entContactCategory = new ContactCategoryENT();
        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();

        entContactCategory = balContactCategory.SelectByPK(ContactCategoryID);

        if (!entContactCategory.ContactCategoryName.IsNull)
        {
            txtContactCategoryName.Text = entContactCategory.ContactCategoryName.Value.ToString();
        }

    }
    #endregion FillControls

    #region Clear Controls
    private void ClearControls()
    {
        txtContactCategoryName.Text = "";
    }

    #endregion Clear Controls

    #region Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation

        String strErrorMessage = "";

        if (txtContactCategoryName.Text.Trim() == "")
        {
            strErrorMessage += "- Enter ContactCategoryName<br/>";
        }
        if (strErrorMessage.Trim() != "")
        {
            lblMessage.Text = strErrorMessage;
            divMessage.Visible = true;
            return;
        }

        #endregion Server Side Validation

        #region Collect Data

        ContactCategoryENT entContactCategory = new ContactCategoryENT();

        if (txtContactCategoryName.Text.Trim() != "")
        {
            entContactCategory.ContactCategoryName = txtContactCategoryName.Text.Trim();
        }

        #endregion Collect Data

        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();

        if (Request.QueryString["ContactCategoryID"] == null)
        {
            #region Insert
            if (balContactCategory.Insert(entContactCategory))
            {
                ClearControls();
                lblMessage.Text = "Data Inserted Successfully";
                divMessage.Visible = true;
            }
            else
            {
                lblMessage.Text = balContactCategory.Message;
                divMessage.Visible = true;
            }
            #endregion Insert
        }
        else
        {
            #region Update
            entContactCategory.ContactCategoryID = Convert.ToInt32(Request.QueryString["ContactCategoryID"]);

            if (balContactCategory.Update(entContactCategory))
            {
                ClearControls();
                Response.Redirect("~/AdminPanel/ContactCategory/ContactCategoryList.aspx", true);
            }
            else
            {
                lblMessage.Text = balContactCategory.Message;
                divMessage.Visible = true;
            }
            #endregion Update
        }
    }
    #endregion Save
}