using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FestivalMarket.Common.Extensions
{
    public static class HtmlHelperExtension
    {
        public static IHtmlString RenderTemplates(this HtmlHelper htmlHelper, string src)
        {
            var diskPath = HttpContext.Current.Server.MapPath(src);
            //var fi = new FileInfo(diskPath);
            //if (!fi.Exists)
            //{
            //    return htmlHelper.Raw(string.Empty);
            //}
            try
            {
                using (var fileStream = new FileStream(diskPath, FileMode.Open, FileAccess.Read))
                {
                    var data = new StringBuilder();
                    using (var sr = new StreamReader(fileStream))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            data.AppendLine(line);
                        }
                    }
                    return htmlHelper.Raw(data);
                }
            }
            catch 
            {
                //ErrorLog.GetDefault(HttpContext.Current).Log(new Error(ex));
                return htmlHelper.Raw(string.Empty);
            }
        }

        public static MvcHtmlString EncodedActionLink(this HtmlHelper htmlHelper, string actionName, string controllerName, object routeValues)
        {
            string queryString = string.Empty;
            if (routeValues != null)
            {
                RouteValueDictionary d = new RouteValueDictionary(routeValues);
                for (int i = 0; i < d.Keys.Count; i++)
                {
                    if (i > 0)
                    {
                        queryString += "&";
                    }
                    queryString += d.Keys.ElementAt(i) + "=" + d.Values.ElementAt(i);
                }
            }

            //What is Entity Framework??
            StringBuilder ancor = new StringBuilder();
            if (controllerName != string.Empty)
            {
                ancor.Append("/" + controllerName);
            }

            if (actionName != "Index")
            {
                ancor.Append("/" + actionName);
            }
            if (queryString != string.Empty)
            {
                ancor.Append("?q=" + Encrypt(queryString));
            }
            return new MvcHtmlString(ancor.ToString());
        }

       

       

        private static string Encrypt(string plainText)
        {
            string key = "jdsg432387#";
            byte[] EncryptKey = { };
            byte[] IV = { 55, 34, 87, 64, 87, 195, 54, 21 };
            EncryptKey = System.Text.Encoding.UTF8.GetBytes(key.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByte = Encoding.UTF8.GetBytes(plainText);
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, des.CreateEncryptor(EncryptKey, IV), CryptoStreamMode.Write);
            cStream.Write(inputByte, 0, inputByte.Length);
            cStream.FlushFinalBlock();
            return Convert.ToBase64String(mStream.ToArray());
        }
    }
}