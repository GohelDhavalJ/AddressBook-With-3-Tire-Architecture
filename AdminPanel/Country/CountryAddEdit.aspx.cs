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

public partial class AdminPanel_Country_CountryAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["CountryID"] != null)
            {
                FillControls(Convert.ToInt32(Request.QueryString["CountryID"]));
            }
        }
    }
    #endregion Load Event

    #region FillControls
    private void FillControls(SqlInt32 CountryID)
    {
        CountryENT entCountry = new CountryENT();
        CountryBAL balCountry = new CountryBAL();

        entCountry = balCountry.SelectByPK(CountryID);

        if (!entCountry.CountryName.IsNull)
        {
            txtCountryName.Text = entCountry.CountryName.Value.ToString();
        }
        if (!entCountry.CountryCode.IsNull)
        {
            txtCountryCode.Text = entCountry.CountryCode.Value.ToString();
        }

    }
    #endregion FillControls

    #region Clear Controls
    private void ClearControls()
    {
        txtCountryName.Text = "";
        txtCountryCode.Text = "";

        txtCountryName.Focus();
    }

    #endregion Clear Controls

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation

        String strErrorMessage = "";

        if(txtCountryName.Text.Trim() == "")
        {
            strErrorMessage += "- Enter CountryName<br/>";
        }
        if (strErrorMessage.Trim() != "")
        {
            lblMessage.Text = strErrorMessage;
            divMessage.Visible = true;
            return;
        }

        #endregion Server Side Validation

        #region Collect Data

        CountryENT entCountry = new CountryENT();

        if (txtCountryName.Text.Trim() != "")
        {
            entCountry.CountryName = txtCountryName.Text.Trim();
        }
        if (txtCountryCode.Text.Trim() != "")
        {
            entCountry.CountryCode = txtCountryCode.Text.Trim();
        }

        #endregion Collect Data

        CountryBAL balCountry = new CountryBAL();

        if (Request.QueryString["CountryID"] == null)
        {
            if (balCountry.Insert(entCountry))
            {
                ClearControls();
                lblMessage.Text = "Data Inserted Successfully";
                divMessage.Visible = true;
            }
            else
            {
                lblMessage.Text = balCountry.Message;
                divMessage.Visible = true;
            }
        }
        else
        {
            entCountry.CountryID = Convert.ToInt32(Request.QueryString["CountryID"]);

            if (balCountry.Update(entCountry))
            {
                ClearControls();
                Response.Redirect("~/AdminPanel/Country/CountryList.aspx", true);
            }
            else
            {
                lblMessage.Text = balCountry.Message;
                divMessage.Visible = true;
            }
        }
    }
    #endregion Button : Save
}