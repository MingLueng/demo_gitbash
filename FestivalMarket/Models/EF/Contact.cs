using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FestivalMarket.Models.EF
{
    [Table("tb_Contact")]
    public class Contact:CommonAbstract
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        [StringLength(150, ErrorMessage = "Không được vượt quá 150 ký tự")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]

        public string Phone { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        public string Message { get; set; }

        public bool IsRead { get; set; }
        public Nullable<byte> IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}