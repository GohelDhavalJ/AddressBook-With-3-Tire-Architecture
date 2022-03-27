using AddressBook.BAL;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CommanFillMethods
/// </summary>
/// 

namespace AddressBook
{
    public class CommanFillMethods
    {
        public CommanFillMethods()
        {

        }
        #region FillDropDownListCountry
        public static void FillDropDownListCountry(DropDownList ddl)
        {
            CountryBAL balCountry = new CountryBAL();
            ddl.DataSource = balCountry.SelectForDropDownList();
            ddl.DataValueField = "CountryID";
            ddl.DataTextField = "CountryName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("--Select Country--", "-1"));
        }
        #endregion FillDropDownListCountry

        #region FillDropDownListState
        public static void FillDropDownListState(DropDownList ddl)
        {
            StateBAL balState = new StateBAL();
            ddl.DataSource = balState.SelectForDropDownList();
            ddl.DataValueField = "StateID";
            ddl.DataTextField = "StateName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("--Select State--", "-1"));
        }
        #endregion FillDropDownListState

        #region FillDropDownListCity
        public static void FillDropDownListCity(DropDownList ddl)
        {
            CityBAL balCity = new CityBAL();
            ddl.DataSource = balCity.SelectForDropDownList();
            ddl.DataValueField = "CityID";
            ddl.DataTextField = "CityName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("--Select City--", "-1"));
        }

        #endregion FillDropDownListCity

        #region FillDropDownListContactCategory
        public static void FillDropDownListContactCategory(DropDownList ddl)
        {
            ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
            ddl.DataSource = balContactCategory.SelectForDropDownList();
            ddl.DataValueField = "ContactCategoryID";
            ddl.DataTextField = "ContactCategoryName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("--Select ContactCategory--", "-1"));
        }

        #endregion FillDropDownListContactCategory

        #region FillDropDownListStateByCountryID
        public static void FillDropDownListStateByCountryID(DropDownList ddl, SqlInt32 CountryID)
        {
            ContactBAL balContact = new ContactBAL();
            ddl.DataSource = balContact.SelectForDropDownListStateByCountryID(CountryID);
            ddl.DataValueField = "StateID";
            ddl.DataTextField = "StateName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("--Select State--", "-1"));
        }
        #endregion FillDropDownListStateByCountryID

        #region FillDropDownListCityByStateID
        public static void FillDropDownListCityByStateID(DropDownList ddl, SqlInt32 StateID)
        {
            ContactBAL balContact = new ContactBAL();
            ddl.DataSource = balContact.SelectForDropDownListCityByStateID(StateID);
            ddl.DataValueField = "CityID";
            ddl.DataTextField = "CityName";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("--Select City--", "-1"));
        }
        #endregion FillDropDownListCityByStateID


    }
}