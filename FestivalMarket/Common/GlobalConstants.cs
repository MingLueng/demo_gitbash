using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FestivalMarket.Common
{
    public class GlobalConstants
    {
        //DML IN CONTEXT
        public static int ACTION_SELECT = 1;
        public static int ACTION_SELECT_ERROR = -1;

        public static int ACTION_INSERT = 2;
        public static int ACTION_INSERT_ERROR = -2;

        public static int ACTION_UPDATE = 3;
        public static int ACTION_UPDATE_ERROR = -3;

        public static int ACTION_DELETE_BYID = 4;
        public static int ACTION_DELETE_BYID_ERROR = -4;

        public static int ACTION_DELETE_OBJECT = 5;
        public static int ACTION_DELETE_OBJECT_ERROR = -5;

        public static int ACTION_DELETE_LIST_OBJECT = 6;
        public static int ACTION_DELETE_LIST_OBJECT_ERROR = -6;

        //ACTION LOGIN

        public static int ACTION_LOGIN_USER = 1;
        public static int ACTION_LOGIN_USER_ERROR = -1;
        public static int ACTION_LOGIN_SUCCESS = 2;
        public static int ACTION_LOGIN_PASSWORD_ERROR = -2;
        public static int ACTION_LOGIN_ERROR = 0;

        //ACTION LOGOUT
        public static int ACTION_LOGOUT_SUCCESS = 1;
        public static int ACTION_LOGOUT_SUCCESS_ERROR = -1;
    }
}