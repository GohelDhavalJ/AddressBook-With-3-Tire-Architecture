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

public partial class AdminPanel_City_CityAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            FillDropDownList();

            if(Request.QueryString["CityID"] != null)
            {
                FillControls(Convert.ToInt32(Request.QueryString["CityID"]));
            }
        }
    }
    #endregion Load Event

    #region Button:Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation

        String strErrorMessage = "";

        if (ddlStateID.SelectedIndex == 0)
        {
            strErrorMessage += "- Select State<br/>";
        }
        if (txtCityName.Text.Trim() == "")
        {
            strErrorMessage += "- Enter CityName<br/>";
        }
        if (strErrorMessage.Trim() != "")
        {
            lblMessage.Text = strErrorMessage;
            divMessage.Visible = true;
            return;
        }

        #endregion Server Side Validation

        #region Collect Data

        CityENT entCity = new CityENT();

        if (ddlStateID.SelectedIndex > 0)
        {
            entCity.StateID = Convert.ToInt32(ddlStateID.SelectedValue);
        }
        if (txtCityName.Text.Trim() != "")
        {
            entCity.CityName = txtCityName.Text.Trim();
        }
        if (txtSTDCode.Text.Trim() != "")
        {
            entCity.STDCode = txtSTDCode.Text.Trim();
        }
        if (txtPincode.Text.Trim() != "")
        {
            entCity.PinCode = txtPincode.Text.Trim();
        }

        #endregion Collect Data

        CityBAL balCity = new CityBAL();

        if (Request.QueryString["CityID"] == null)
        {
            #region Insert
            if (balCity.Insert(entCity))
            {
                ClearControls();
                lblMessage.Text = "Data Inserted Successfully";
                divMessage.Visible = true;
            }
            else
            {
                lblMessage.Text = balCity.Message;
                divMessage.Visible = true;
            }
            #endregion Insert
        }
        else
        {
            #region Update

            entCity.CityID = Convert.ToInt32(Request.QueryString["CityID"]);

            if(balCity.Update(entCity))
            {
                ClearControls();
                Response.Redirect("~/AdminPanel/City/CityList.aspx", true);
            }
            else
            {
                lblMessage.Text = balCity.Message;
                divMessage.Visible = true;
            }
            #endregion Update
        }
    }
    #endregion Button:Save

    #region FillControls
    private void FillControls(SqlInt32 CityID)
    {
        CityENT entCity = new CityENT();
        CityBAL balCity = new CityBAL();

        entCity = balCity.SelectByPK(CityID);

        if(!entCity.StateID.IsNull)
        {
            ddlStateID.SelectedValue = entCity.StateID.Value.ToString();
        }
        if(!entCity.CityName.IsNull)
        {
            txtCityName.Text = entCity.CityName.Value.ToString();
        }
        if (!entCity.STDCode.IsNull)
        {
            txtSTDCode.Text = entCity.STDCode.Value.ToString();
        }
        if (!entCity.PinCode.IsNull)
        {
            txtPincode.Text = entCity.PinCode.Value.ToString();
        }

    }
    #endregion FillControls

    #region FillDropDownList
    private void FillDropDownList()
    {
        CommanFillMethods.FillDropDownListState(ddlStateID);
    }
    #endregion FillDropDownList

    #region Clear Controls
    private void ClearControls()
    {
        ddlStateID.SelectedIndex = 0;
        txtCityName.Text = "";
        txtPincode.Text = "";
        txtSTDCode.Text = "";

        ddlStateID.Focus();
    }

    #endregion Clear Controls

}