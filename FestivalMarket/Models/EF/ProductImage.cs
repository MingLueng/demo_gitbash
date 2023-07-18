﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FestivalMarket.Models.EF
{
    [Table("tb_ProductImage")]
    public class ProductImage
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //[Required]
        public int ProductId { get; set; }
      
        //[StringLength(250)]

        public string Image { get; set; }


   
        public bool IsDelete { get; set; }

        public virtual Product Product { get; set; }

    }
}