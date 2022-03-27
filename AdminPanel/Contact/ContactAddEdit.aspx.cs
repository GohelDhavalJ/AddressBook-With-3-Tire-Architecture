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

public partial class AdminPanel_Contact_ContactAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownList();

            if (Request.QueryString["ContactID"] != null)
            {
                FillControls(Convert.ToInt32(Request.QueryString["ContactID"]));
            }
            
        }
    }

    #endregion Load Event

    #region Fill Controls
    private void FillControls(SqlInt32 ContactID)
    {
        ContactENT entContact = new ContactENT();
        ContactBAL balContact = new ContactBAL();

        entContact = balContact.SelectByPK(ContactID);

        if (!entContact.CountryID.IsNull)
        {
            ddlCountryID.SelectedValue = entContact.CountryID.Value.ToString();

        }
        if (!entContact.StateID.IsNull)
        {
            ddlStateID.SelectedValue = entContact.StateID.Value.ToString();

        }
        if (!entContact.CityID.IsNull)
        {
            ddlCityID.SelectedValue = entContact.CityID.Value.ToString();
        }

        if (!entContact.ContactCategoryID.IsNull)
        {
            ddlContactCategoryID.SelectedValue = entContact.ContactCategoryID.Value.ToString();
        }

        if (!entContact.ContactName.IsNull)
        {
            txtContactName.Text = entContact.ContactName.Value.ToString();
        }

        if (!entContact.ContactNo.IsNull)
        {
            txtContactNo.Text = entContact.ContactNo.Value.ToString();
        }

        if (!entContact.Email.IsNull)
        {
            txtEmail.Text = entContact.Email.Value.ToString();
        }

        if (!entContact.Address.IsNull)
        {
            txtAddress.Text = entContact.Address.Value.ToString();
        }
        if (!entContact.WhatsAppNo.IsNull)
        {
            txtWhatsAppNo.Text = entContact.WhatsAppNo.Value.ToString();
        }
        if (!entContact.BirthDate.IsNull)
        {
            txtBirthdate.Text = entContact.BirthDate.Value.ToString();
        }
        if (!entContact.Age.IsNull)
        {
            txtAge.Text = entContact.Age.Value.ToString();
        }

        if (!entContact.BloodGroup.IsNull)
        {
            txtBloodGroup.Text = entContact.BloodGroup.Value.ToString();
        }

        if (!entContact.FaceBookID.IsNull)
        {
            txtFaceBookID.Text = entContact.FaceBookID.Value.ToString();
        }
        if (!entContact.LinkedINID.IsNull)
        {
            txtLinkedINID.Text = entContact.LinkedINID.Value.ToString();
        }
        FillDropDownList();
    }

    #endregion Fill Controls

    #region Clear Controls
    private void ClearControls()
    {
        ddlCountryID.SelectedIndex = 0;
        ddlStateID.SelectedIndex = 0;
        ddlCityID.SelectedIndex = 0;
        ddlContactCategoryID.SelectedIndex = 0;
        txtContactName.Text = "";
        txtContactNo.Text = "";
        txtWhatsAppNo.Text = "";
        txtBirthdate.Text = "";
        txtEmail.Text = "";
        txtAge.Text = "";
        txtAddress.Text = "";
        txtBloodGroup.Text = "";
        txtFaceBookID.Text = "";
        txtLinkedINID.Text = "";
        ddlCountryID.Focus();
    }
    #endregion Clear Controls

    #region Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        String strErrorMessage = "";

        if (ddlCountryID.SelectedIndex == 0)
        {
            strErrorMessage += "- Select Country <br/>";
        }

        if (ddlStateID.SelectedIndex == 0)
        {
            strErrorMessage += "- Select State <br/>";
        }

        if (ddlCityID.SelectedIndex == 0)
        {
            strErrorMessage += "- Select City <br/>";
        }

        if (ddlContactCategoryID.SelectedIndex == 0)
        {
            strErrorMessage += "- Select ContactCategory <br/>";
        }

        if (txtContactName.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Contact Name <br/>";
        }

        if (txtContactNo.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Contact Number <br/>";
        }

        if (txtEmail.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Email I'D <br/>";
        }

        if (txtAddress.Text.Trim() == "")
        {
            strErrorMessage += "- Enter Your Address <br/>";
        }


        if (strErrorMessage.Trim() != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        #region Gather Information
        ContactENT entContact = new ContactENT();
        //Gather the Information
        if (ddlCountryID.SelectedIndex > 0)
        {
            entContact.CountryID = Convert.ToInt32(ddlCountryID.SelectedValue);

        }
        if (ddlStateID.SelectedIndex > 0)
        {
            entContact.StateID = Convert.ToInt32(ddlStateID.SelectedValue);

        }
        if (ddlCityID.SelectedIndex > 0)
        {
            entContact.CityID = Convert.ToInt32(ddlCityID.SelectedValue);
        }

        if (ddlContactCategoryID.SelectedIndex > 0)
        {
            entContact.ContactCategoryID = Convert.ToInt32(ddlContactCategoryID.SelectedValue);
        }

        if (txtContactName.Text.Trim() != "")
        {
            entContact.ContactName = txtContactName.Text.Trim();
        }

        if (txtContactNo.Text.Trim() != "")
        {
            entContact.ContactNo = txtContactNo.Text.Trim();
        }

        if (txtEmail.Text.Trim() != "")
        {
            entContact.Email = txtEmail.Text.Trim();
        }

        if (txtAddress.Text.Trim() != "")
        {
            entContact.Address = txtAddress.Text.Trim();
        }
        if (txtWhatsAppNo.Text.Trim() != "")
        {
            entContact.WhatsAppNo = txtWhatsAppNo.Text.Trim();
        }
        if (txtBirthdate.Text.Trim() != "")
        {
            entContact.BirthDate = Convert.ToDateTime(txtBirthdate.Text.Trim());
        }
        if (txtAge.Text.Trim() != "")
        {
            entContact.Age = Convert.ToInt32(txtAge.Text.Trim());
        }

        if (txtBloodGroup.Text.Trim() != "")
        {
            entContact.BloodGroup = txtBloodGroup.Text.Trim();
        }

        if (txtFaceBookID.Text.Trim() != "")
        {
            entContact.FaceBookID = txtFaceBookID.Text.Trim();
        }
        if (txtLinkedINID.Text.Trim() != "")
        {
            entContact.LinkedINID = txtLinkedINID.Text.Trim();
        }
        #endregion Gather Information

        ContactBAL balContact = new ContactBAL();

        #region Insert
        if (Request.QueryString["ContactID"] == null)
        {
            if (balContact.Insert(entContact))
            {
                ClearControls();
                lblMessage.Text = "Data Inserted Successfully";
                divMessage.Visible = true;
            }

            else
            {
                lblMessage.Text = balContact.Message;
                divMessage.Visible = true;
            }
        }
        #endregion Insert

        #region Update
        else
        {
            entContact.ContactID = SqlInt32.Parse(Request.QueryString["ContactID"].ToString().Trim());
            if (balContact.Update(entContact))
            {
                ClearControls();
                Response.Redirect("~/AdminPanel/Contact/ContactList.aspx", true);
                lblMessage.Text = "Data Upadate Successfully";
            }

            else
            {
                lblMessage.Text = balContact.Message;
                divMessage.Visible = true;
            }
        }
        #endregion Update
    }
    #endregion Save

    #region ddlCountry - Selected Index Changed
    protected void ddlCountryID_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Fill State dropdown list
        if (ddlCountryID.SelectedIndex > 0)
        {
            CommanFillMethods.FillDropDownListStateByCountryID(ddlStateID, SqlInt32.Parse(ddlCountryID.SelectedValue));
        }
        else
        {
            ddlStateID.Items.Clear();
            ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));

            ddlCityID.Items.Clear();
            ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));
        }
    }
    #endregion ddlCountry - Selected Index Changed

    #region ddlState - Selected Index Changed
    protected void ddlStateID_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Fill City DropDown List

        if (ddlStateID.SelectedIndex > 0)
        {
            CommanFillMethods.FillDropDownListCityByStateID(ddlCityID, SqlInt32.Parse(ddlStateID.SelectedValue));
        }
        else
        {
            ddlCityID.Items.Clear();
            ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));

        }
    }
    #endregion ddlState - Selected Index Changed

    #region Fill DropDownList
    private void FillDropDownList()
    {
        CommanFillMethods.FillDropDownListCountry(ddlCountryID);
        CommanFillMethods.FillDropDownListStateByCountryID(ddlStateID, SqlInt32.Parse(ddlCountryID.SelectedValue.ToString()));
        CommanFillMethods.FillDropDownListCityByStateID(ddlCityID, SqlInt32.Parse(ddlStateID.SelectedValue.ToString()));
        CommanFillMethods.FillDropDownListContactCategory(ddlContactCategoryID);
    }
    #endregion Fill DropDownList
}