using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StateENT
/// </summary>
/// 
namespace AddressBook.ENT
{
    public class StateENT
    {
        #region Constructor
        public StateENT()
        {

        }
        #endregion Constructor

        #region StateID

        protected SqlInt32 _StateID;

        public SqlInt32 StateID
        {
            get
            {
                return _StateID;
            }
            set
            {
                _StateID = value;
            }
        }

        #endregion StateID

        #region CountryID

        protected SqlInt32 _CountryID;

        public SqlInt32 CountryID
        {
            get
            {
                return _CountryID;
            }
            set
            {
                _CountryID = value;
            }
        }

        #endregion CountryID

        #region StateName

        protected SqlString _StateName;

        public SqlString StateName
        {
            get
            {
                return _StateName;
            }
            set
            {
                _StateName = value;
            }
        }

        #endregion StateName

        #region Statecode

        protected SqlString _Statecode;

        public SqlString Statecode
        {
            get
            {
                return _Statecode;
            }
            set
            {
                _Statecode = value;
            }
        }

        #endregion Statecode
    }
}