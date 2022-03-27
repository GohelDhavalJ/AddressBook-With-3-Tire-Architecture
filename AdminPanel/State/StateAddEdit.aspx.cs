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

public partial class AdminPanel_State_StateAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownList();

            if(Request.QueryString["StateID"] != null)
            {
                FillControls(Convert.ToInt32(Request.QueryString["StateID"]));
            }
        }
    }
    #endregion Load Event

    #region FillControls
    private void FillControls(SqlInt32 StateID)
    {
        StateENT unused = new StateENT();
        StateBAL balState = new StateBAL();

        StateENT entState = balState.SelectByPK(StateID);

        if (!entState.CountryID.IsNull)
        {
            ddlCountryID.SelectedValue = entState.CountryID.Value.ToString();
        }
        if (!entState.StateName.IsNull)
        {
            txtStateName.Text = entState.StateName.Value.ToString();
        }
        if (!entState.Statecode.IsNull)
        {
            txtStateCode.Text = entState.Statecode.Value.ToString();
        }
    }
    #endregion FillControls

    #region FillDropDownList
    private void FillDropDownList()
    {
        CommanFillMethods.FillDropDownListCountry(ddlCountryID);
    }
    #endregion FillDropDownList

    #region Clear Controls
    private void ClearControls()
    {
        ddlCountryID.SelectedIndex = 0;
        txtStateName.Text = "";
        txtStateCode.Text = "";

        ddlCountryID.Focus();
    }
    #endregion Clear Controls

    #region Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation

        String strErrorMessage = "";

        if(ddlCountryID.SelectedIndex == 0)
        {
            strErrorMessage += "- Select Country<br/>";
        }
        if (txtStateName.Text.Trim() == "")
        {
            strErrorMessage += "- Select StateName";
        }
        if (strErrorMessage.Trim() != "")
        {
            lblMessage.Text = strErrorMessage;
            divMessage.Visible = true;
            return;
        }

        #endregion Server Side Validation

        #region Collect Data

        StateENT entState = new StateENT();

        if (ddlCountryID.SelectedIndex > 0)
        {
            entState.CountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
        }
        if (txtStateName.Text.Trim() != "")
        {
            entState.StateName = txtStateName.Text.Trim();
        }
        if (txtStateCode.Text.Trim() != "")
        {
            entState.Statecode = txtStateCode.Text.Trim();
        }
           

        #endregion CollectData

        StateBAL balState = new StateBAL();

        if(Request.QueryString["StateID"] == null)
        {
            if (balState.Insert(entState))
            {
                ClearControls();
                lblMessage.Text = "Data Inserted Successfully";
                divMessage.Visible = true;
            }
            else
            {
                lblMessage.Text = balState.Message;
                divMessage.Visible = true;
            }
        }
        else
        {
            entState.StateID = Convert.ToInt32(Request.QueryString["StateID"]);

            if (balState.Update(entState))
            {
                ClearControls();
                Response.Redirect("~/AdminPanel/State/StateList.aspx", true);
            }
            else
            {
                lblMessage.Text = balState.Message;
                divMessage.Visible = true;
            }
        }

    }

    #endregion Save
}