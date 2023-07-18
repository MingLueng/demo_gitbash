using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FestivalMarket.Models.EF
{
    [Table("tb_Product")]
    public class Product : CommonAbstract
    {
        public Product()
        {
            this.ProductImage = new HashSet<ProductImage>();

        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //[Required]
        //[StringLength(250)]
        public string Title { get; set; }
        //[StringLength(250)]
        public string Alias { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }
        //[AllowHtml]
        public string Detail { get; set; }
    
        //[StringLength(250)]
        public string Image { get; set; }
        //[StringLength(50)]
        public string ProductCode { get; set; }
        /*[Required(ErrorMessage = "Danh mục tin tức không được để trống")]
        public int ProductCategoryId { get; set; }*/
        public decimal Price { get; set; }
        public decimal? PriceSale { get; set; }
        public int Quantity { get; set; }
        public bool IsHot { get; set; }
        public bool IsHome { get; set; }
        public bool IsSale { get; set; }
        public int Views { get; set; }
        public string Slug { get; set; }
        public int Order { get; set; }
        public bool Highlight { get; set; }
        public int Likes { get; set; }
        public double Star { get; set; }
        public Nullable<byte> IsActive { get; set; }
        public bool IsDelete { get; set; }
        public bool IsFeature { get; set; }
        [StringLength(250)]
        public string SeoTitle { get; set; }
        [StringLength(500)]

        public string SeoDescription { get; set; }
        [StringLength(250)]

        public string SeoKeywords { get; set; }
        public string MAIN_KEYWORD { get; set; }


        public virtual ICollection<ProductImage> ProductImage { get; set; }
    }
}