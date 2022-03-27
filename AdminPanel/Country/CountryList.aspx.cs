using AddressBook.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Country_CountryList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillCountryGridView();
        }
    }
    #endregion Load Event

    #region FillGridView
    public void FillCountryGridView()
    {
        CountryBAL balCountry = new CountryBAL();
        DataTable dtCountry = new DataTable();

        dtCountry = balCountry.SelectAll();

        if(dtCountry != null && dtCountry.Rows.Count > 0)
        {
            gvCountry.DataSource = dtCountry;
            gvCountry.DataBind();
        }
    }
    #endregion FillGridView

    #region gvRowCommand
    protected void gvCountry_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName == "DeleteRecord")
        {
            if(e.CommandArgument != null)
            {
                CountryBAL balCountry = new CountryBAL();
                if (balCountry.DeleteCountry(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    FillCountryGridView();
                }
                else
                {
                    lblDisplay.Text = balCountry.Message;
                    divMessage.Visible = true;
                }
            }
        }
    }
    #endregion gvRowCommand
}