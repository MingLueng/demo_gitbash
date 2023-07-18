﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FestivalMarket.Models.EF
{
    [Table("tb_Introduction")]
    public class Introduction:CommonAbstract
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //[Required(ErrorMessage = "Tiêu đề tin tức không được để trống")]
        //[StringLength(150)]
        public string Title { get; set; }
        public string Description { get; set; }
        //[AllowHtml]
        public string Detail { get; set; }

        public string Code { get; set; }
        public string Slug { get; set; }
        public int Order { get; set; }
        public int Views { get; set; }
        public int Likes { get; set; }
        public double Star { get; set; }
        //[StringLength(250)]
        public string Image { get; set; }
        public string Alias { get; set; }
        //[StringLength(250)]
        public string SeoTitle { get; set; }
        //[StringLength(500)]
        public string SeoDescription { get; set; }
        //[StringLength(250)]
        public string SeoKeywords { get; set; }
        public Nullable<byte> IsActive { get; set; }
        public bool IsDelete { get; set; }

      
    }
}