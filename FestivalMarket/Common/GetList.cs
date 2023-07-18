using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FestivalMarket.Common
{
    public static class GetList
    {

        private static List<Title> GetTitles(Dictionary<string, object> keyValuePairs, Object obj, IList<string> lstColumnActive)
        {

            List<Title> Titles = new List<Title>();

            foreach (var item in keyValuePairs)
            {
                Title title = new Title
                {
                    Key = item.Key,
                    Name = GetDisplayNameMetaData.GetDisplayName(obj, item.Key),
                    isDisplay = (lstColumnActive.Count == 0) ? true : lstColumnActive.Contains(item.Key)
                };
                Titles.Add(title);
            }

            return Titles;
        }
        public static List<Title> GetTitles(Object obj, IList<string> lstColumnActive)
        {
            return GetTitles(ConvertToDictionary.keyValuePairs(obj), obj, lstColumnActive);

        }
    }
}