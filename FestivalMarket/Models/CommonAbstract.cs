﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FestivalMarket.Models
{
    public class CommonAbstract
    {
       
            public string CreatedBy { get; set; }
            public Nullable<System.DateTime> CreatedDate { get; set; }
            public string ModifiedBy { get; set; }
            public Nullable<System.DateTime> ModifiedDate { get; set; }
        
    }
}