﻿using AddressBook.DAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CountryBAL
/// </summary>
/// 
namespace AddressBook.BAL
{
    public class CountryBAL
    {
        #region Constructor
        public CountryBAL()
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

        #endregion Local Variables

        #region Insert
        public Boolean Insert(CountryENT entCountry)
        {
            CountryDAL dalCountry = new CountryDAL();

            if (dalCountry.Insert(entCountry))
            {
                return true;
            }
            else
            {
                Message = dalCountry.Message;
                return false;
            }
        }
        #endregion Insert

        #region Update
        public Boolean Update(CountryENT entCountry)
        {
            CountryDAL dalCountry = new CountryDAL();

            if (dalCountry.Update(entCountry))
            {
                return true;
            }
            else
            {
                Message = dalCountry.Message;
                return false;
            }
        }
        #endregion Update

        #region Delete
        public Boolean DeleteCountry(SqlInt32 CountryID)
        {
            CountryDAL dalCountry = new CountryDAL();

            if (dalCountry.DeleteCountry(CountryID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion Delete

        #region Select

        #region SelectAll 
        public DataTable SelectAll()
        {
            CountryDAL dalCountry = new CountryDAL();
            return dalCountry.SelectAll();
        }
        #endregion SelectAll 

        #region SelectDropDownList
        public DataTable SelectForDropDownList()
        {
            CountryDAL dalCountry = new CountryDAL();
            return dalCountry.SelectForDropDownList();
        }
        #endregion SelectDropDownList

        #region SelectByPK
        public CountryENT SelectByPK(SqlInt32 CountryID)
        {
            CountryDAL dalCountry = new CountryDAL();
            return dalCountry.SelectByPK(CountryID);
        }

        #endregion SelectByPK

        #endregion Select
    }
}