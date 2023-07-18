using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FestivalMarket.Models.EF
{
    [Table("tb_Slides")]
    public class Slides:CommonAbstract
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //[Required(ErrorMessage = "Tiêu đề tin tức không được để trống")]
        //[StringLength(150)]
        public string Title { get; set; }
        public string Sub_Title { get; set; }
     
        public string Urls { get; set; }
        //[StringLength(250)]
        public string Image { get; set; }
     
        //[StringLength(500)]
        public string Notes { get; set; }
        public string Slug { get; set; }
        public int Order { get; set; }

        public string Code { get; set; }

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

	