using AddressBook.DAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CityBAL
/// </summary>

namespace AddressBook.BAL
{
    public class CityBAL
    {
        #region Constructor
        public CityBAL()
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

        #region Delete
        public Boolean DeleteCity(SqlInt32 CityID)
        {
            CityDAL dalCity = new CityDAL();

            if (dalCity.DeleteCity(CityID))
            {
                return true;
            }
            else
            {
                Message = dalCity.Message;
                return false;
            }
        }

        #endregion Delete

        #region Insert
        public Boolean Insert(CityENT entCity)
        {
            CityDAL dalCity = new CityDAL();

            if (dalCity.Insert(entCity))
            {
                return true;
            }
            else
            {
                Message = dalCity.Message;
                return false;
            }
        }

        #endregion Insert

        #region Update
        public Boolean Update(CityENT entCity)
        {
            CityDAL dalCity = new CityDAL();

            if (dalCity.Update(entCity))
            {
                return true;
            }
            else
            {
                Message = dalCity.Message;
                return false;
            }
        }

        #endregion Update

        #region Select

        #region SelectAll 
        public DataTable SelectAll()
        {
            CityDAL dalCity = new CityDAL();
            return dalCity.SelectAll();
        }

        #endregion SelectAll

        #region SelectDropDownList
        public DataTable SelectForDropDownList()
        {
            CityDAL dalCity = new CityDAL();
            return dalCity.SelectForDropDownList();
        }

        #endregion SelectDropDownList

        #region SelectByPK
        public CityENT SelectByPK(SqlInt32 CityID)
        {
            CityDAL dalCity = new CityDAL();
            return dalCity.SelectByPK(CityID);
        }
        #endregion SelectByPK

        #endregion Select
    }
}