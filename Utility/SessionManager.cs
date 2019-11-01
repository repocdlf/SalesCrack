using SalesCrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace SalesCrack.Utility
{
    public class SessionManager
    {
        private static Boolean UseCache = false;

        public static Credential GetCurrentUser()
        {
            Credential currentUser = null;
            if (SessionManager.UseCache)
            {
                currentUser = (Credential)System.Web.HttpContext.Current.Cache["current_user"];
            } else
            {
                currentUser = (Credential)System.Web.HttpContext.Current.Session["current_user"];
            }
            return currentUser;
        }

        public static void SetCurrentUser(Credential credent)
        {
            if (SessionManager.GetCurrentUser() == null)
            {
                if (SessionManager.UseCache)
                {
                    System.Web.HttpContext.Current.Cache["current_user"] = credent;
                }
                else
                {
                    System.Web.HttpContext.Current.Session["current_user"] = credent;
                }
            }
        }

        public static void RemoveCurrentUser()
        {
            if (SessionManager.UseCache)
            {
                System.Web.HttpContext.Current.Cache.Remove("current_user");
            }
            else
            {
                System.Web.HttpContext.Current.Session.Remove("current_user");
            }
        }
    }
}