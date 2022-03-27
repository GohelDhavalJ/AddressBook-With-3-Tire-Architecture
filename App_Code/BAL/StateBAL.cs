using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StateBAL
/// </summary>
/// 
namespace AddressBook.BAL
{
    public class StateBAL
    {
        #region Constructor
        public StateBAL()
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
        public Boolean Insert(StateENT entState)
        {
            StateDAL dalState = new StateDAL();

            if (dalState.Insert(entState))
            {
                return true;
            }
            else
            {
                Message = dalState.Message;
                return false;
            }
        }
        #endregion Insert

        #region Update
        public Boolean Update(StateENT entState)
        {
            StateDAL dalState = new StateDAL();

            if (dalState.Update(entState))
            {
                return true;
            }
            else
            {
                Message = dalState.Message;
                return false;
            }
        }
        #endregion Update

        #region Delete
        public Boolean DeleteState(SqlInt32 StateID)
        {
            StateDAL dalState = new StateDAL();

            if (dalState.DeleteState(StateID))
            {
                return true;
            }
            else
            {
                Message = dalState.Message;
                return false;
            }
        }
        #endregion Delete

        #region Select

        #region SelectAll
        public DataTable SelectAll()
        {
            StateDAL dalState = new StateDAL();
            return dalState.SelectAll();
        }
        #endregion SelectAll

        #region SelectForDropDownList
        public DataTable SelectForDropDownList()
        {
            StateDAL dalState = new StateDAL();
            return dalState.SelectForDropDownList();
        }
        #endregion SelectForDropDownList

        #region SelectByPK
        public StateENT SelectByPK(SqlInt32 StateID)
        {
            StateDAL dalState = new StateDAL();
            return dalState.SelectByPK(StateID);
        }
        #endregion SelectByPK

        #endregion Select
    }
}