using AddressBook.DAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactBAL
/// </summary>
/// 
namespace AddressBook.BAL
{
    public class ContactBAL
    {
        #region Constructor
        public ContactBAL()
        {

        }
        #endregion Constructor

        #region Local Variables
        protected string _Message;
        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }
        protected SqlInt32 _ContactID;
        public SqlInt32 ContactID
        {
            get
            {
                return _ContactID;
            }
            set
            {
                _ContactID = value;
            }
        }
        #endregion Local Variables

        #region Insert Operation

        #region Insert Contact
        public Boolean Insert(ContactENT entContact)
        {
            ContactDAL dalContact = new ContactDAL();
            if (dalContact.Insert(entContact))
            {
                return true;
            }
            else
            {
                Message = dalContact.Message;
                return false;
            }
        }
        #endregion Insert Contact

        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(ContactENT entContact)
        {
            ContactDAL dalContact = new ContactDAL();
            if (dalContact.Update(entContact))
            {
                return true;
            }
            else
            {
                Message = dalContact.Message;
                return false;
            }
        }

        #endregion Update Operation

        #region Delete Operation

        #region Delete Contact
        public Boolean Delete(SqlInt32 ContactID)
        {
            ContactDAL dalContact = new ContactDAL();

            if (dalContact.Delete(ContactID))
            {
                return true;
            }
            else
            {
                Message = dalContact.Message;
                return false;
            }
        }
        #endregion Delete Contact

        #endregion Delete Operation

        #region Select Operation

        #region SelectAll
        public DataTable SelectAll()
        {
            ContactDAL dalContact = new ContactDAL();
            return dalContact.SelectAll();
        }
        #endregion SelectAll

        #region SelectByPK
        public ContactENT SelectByPK(SqlInt32 ContactID)
        {
            ContactDAL dalContact = new ContactDAL();
            return dalContact.SelectByPK(ContactID);
        }
        #endregion SelectByPK

        #region SelectForDropDownListCountry
        public DataTable SelectForDropDownListCountry()
        {
            ContactDAL dalContact = new ContactDAL();
            return dalContact.SelectForDropDownListCountry();
        }
        #endregion SelectForDropDownListCountry

        #region SelectForDropDownListContactCategory
        public DataTable SelectForDropDownListContactCategory()
        {
            ContactDAL dalContact = new ContactDAL();
            return dalContact.SelectForDropDownListContactCategory();
        }
        #endregion SelectForDropDownListContactCategory

        #region SelectForDropDownListStateByCountryID
        public DataTable SelectForDropDownListStateByCountryID(SqlInt32 CountryID)
        {
            ContactDAL dalContact = new ContactDAL();
            return dalContact.SelectForDropDownListStateByCountryID(CountryID);
        }
        #endregion SelectForDropDownListStateByCountryID

        #region SelectForDropDownListCityByStateID
        public DataTable SelectForDropDownListCityByStateID(SqlInt32 StateID)
        {
            ContactDAL dalContact = new ContactDAL();
            return dalContact.SelectForDropDownListCityByStateID(StateID);
        }
        #endregion SelectForDropDownListCityByStateID

        #endregion Select Operation

    }
}