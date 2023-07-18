using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FestivalMarket.Models.EF
{
    [Table("tb_CategoryFilm")]
    public class CategoryFilm : CommonAbstract
    {
        public CategoryFilm()
        {

            this.FilmsView = new HashSet<FilmsView>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /*[Required(ErrorMessage = "Tên danh mục không được để trống")]
        [StringLength(150)]*/
        public string Title { get; set; }

        public string Icon { get; set; }
        /* [StringLength(150)]*/
        public string Description { get; set; }
        //[StringLength(150)]

        public string SeoTitle { get; set; }
        //[StringLength(150)]
        public string SeoDescription { get; set; }
        //[StringLength(150)]
        public string SeoKeywords { get; set; }
        public string Alias { get; set; }

        public int Order { get; set; }
        public string Slug { get; set; }
        public int Views { get; set; }
        public int Likes { get; set; }
        public double Star { get; set; }
        public Nullable<byte> IsActive { get; set; }
        public bool IsDelete { get; set; }
        public ICollection<FilmsView> FilmsView { get; set; }

    }
}