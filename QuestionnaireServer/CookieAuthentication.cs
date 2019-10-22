using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace QuestionnaireServer
{
    public static class CookieAuthentication
    {
        /// <summary>
        /// Checks if there is a valid authentication ticket in the client request's cookies.
        /// </summary>
        /// <param name="pageContext">Context of the caller page.</param>
        /// <returns></returns>
        public static bool IsSet(HttpCookieCollection cookies)
        {
            HttpCookie authCookie = cookies != null ? cookies[FormsAuthentication.FormsCookieName] : null;
            FormsAuthenticationTicket authTicket = null;
            if (authCookie == null)
            {
                return false;
            }
            try
            {
                authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                return authTicket != null;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Retrieves the authenticated student's ID, should be called after IsSet in order to avoid NullReferenceException.
        /// </summary>
        /// <param name="pageContext">Context of the caller page.</param>
        /// <returns></returns>
        public static Guid GetStudentID(HttpCookieCollection cookies)
        {
            HttpCookie authCookie = cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            return new Guid(new FormsIdentity(authTicket).Name);
        }

        /// <summary>
        /// Expires all the cookies stored in the client.
        /// </summary>
        public static void ExpireAllCookies(HttpCookieCollection reqCookies, HttpCookieCollection resCookies)
        {
            foreach (string cookieName in reqCookies.AllKeys)
            {
                //DateTime.Now.AddYears(-30) is safer because of default dates and synchronization issues
                HttpCookie expiredCookie = new HttpCookie(cookieName) { Expires = DateTime.Now.AddYears(-30) };
                resCookies.Add(expiredCookie);
            }
        }
    }
}