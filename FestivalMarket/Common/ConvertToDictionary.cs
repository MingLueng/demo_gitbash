using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FestivalMarket.Common
{
    public static class ConvertToDictionary
    {
        public static Dictionary<string, object> keyValuePairs(Object obj)
        {
            var jsonData = JsonConvert.SerializeObject(obj);
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonData);
            return dictionary;
        }

    }
}