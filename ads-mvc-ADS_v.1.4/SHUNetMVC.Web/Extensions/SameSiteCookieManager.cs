using Microsoft.Owin.Infrastructure;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHUNetMVC.Web.Extensions
{
    public class SameSiteCookieManager : ICookieManager
    {
        private readonly ICookieManager _innerManager;

        public SameSiteCookieManager(ICookieManager innerManager)
        {
            _innerManager = innerManager ?? throw new ArgumentNullException(nameof(innerManager));
        }

        public void AppendResponseCookie(IOwinContext context, string key, string value, CookieOptions options)
        {
            // Set SameSite=None and Secure for the authentication cookie
            if (string.Equals(key, CookieAuthenticationDefaults.CookiePrefix + CookieAuthenticationDefaults.AuthenticationType, StringComparison.OrdinalIgnoreCase))
            {
                options.SameSite = Microsoft.Owin.SameSiteMode.None;
                options.Secure = true;
            }

            _innerManager.AppendResponseCookie(context, key, value, options);
        }

        public void DeleteCookie(IOwinContext context, string key, CookieOptions options)
        {
            _innerManager.DeleteCookie(context, key, options);
        }

        public string GetRequestCookie(IOwinContext context, string key)
        {
            return _innerManager.GetRequestCookie(context, key);
        }
    }


}